﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using DurableTask.Core;
using DurableTask.Core.Serializing;
using LLL.DurableTask.Core.Serializing;
using Newtonsoft.Json.Linq;

namespace LLL.DurableTask.Worker.Orchestrations;

public class MethodTaskActivity : TaskActivity
{
    private readonly MethodInfo _methodInfo;
    private readonly DataConverter _dataConverter;

    public MethodTaskActivity(
        object instance,
        MethodInfo methodInfo)
    {
        Instance = instance;
        _methodInfo = methodInfo;
        _dataConverter = new TypelessJsonDataConverter();
    }

    public object Instance { get; }

    public override string Run(TaskContext context, string input)
    {
        throw new NotImplementedException();
    }

    public override async Task<string> RunAsync(TaskContext context, string input)
    {
        var parameters = PrepareParameters(input, new Dictionary<Type, Func<object>>
        {
            [typeof(TaskContext)] = () => context
        });

        try
        {
            var result = _methodInfo.Invoke(Instance, parameters);
            return await SerializeResult(result);
        }
        catch (TargetInvocationException ex)
        {
            ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
            throw;
        }
    }

    private object[] PrepareParameters(
        string input,
        Dictionary<Type, Func<object>> factories)
    {
        var jsonParameters = _dataConverter.Deserialize<JToken[]>(input);

        var inputPosition = 0;

        var parameters = new List<object>();

        foreach (var parameter in _methodInfo.GetParameters())
        {
            object value;

            if (factories.TryGetValue(parameter.ParameterType, out var factory))
            {
                value = factory();
            }
            else if (inputPosition < jsonParameters.Length)
            {
                value = jsonParameters[inputPosition++].ToObject(parameter.ParameterType);
            }
            else if (parameter.IsOptional)
            {
                value = parameter.DefaultValue;
            }
            else
                throw new Exception($"Activity expects at least {inputPosition + 1} parameters but {jsonParameters.Length} were provided.");

            parameters.Add(value);
        }

        return parameters.ToArray();
    }

    private async Task<string> SerializeResult(object result)
    {
        // Store the original result in a local variable
        var localResult = result;

        // Check if the result is a non-null Task (could be Task or Task<T>)
        if (localResult is not null and Task task)
        {
            // Reset localResult as we will replace it after awaiting the task
            localResult = null;

            // Await the task to ensure it's completed before accessing its result
            await task.ConfigureAwait(false);

            // Check if method return type if a generic Task (i.e., Task<T>)
            if (_methodInfo.ReturnType.IsGenericType)
            {
                // Get the runtime type of the task (might be compiler-generated)
                var currentType = task.GetType();

                // Get the 'Result' property from the Task<T> type
                var resultProperty = currentType.GetProperty(nameof(Task<object>.Result));
                if (resultProperty != null)
                {
                    // Retrieve the result from the completed Task<T>
                    localResult = resultProperty.GetValue(task);
                }
            }
        }

        return _dataConverter.Serialize(localResult);
    }
}
