﻿using System;
using DurableTask.Core;
using DurableTask.Core.History;
using LLL.DurableTask.EFCore.Entities;
using Microsoft.Extensions.Options;

namespace LLL.DurableTask.EFCore.Mappers
{
    public class OrchestrationMessageMapper
    {
        private readonly EFCoreOrchestrationOptions _options;

        public OrchestrationMessageMapper(IOptions<EFCoreOrchestrationOptions> options)
        {
            _options = options.Value;
        }

        public OrchestrationMessage CreateOrchestrationMessage(
            TaskMessage message,
            int sequence,
            string orchestrationQueue,
            string parentOrchestrationQueue)
        {
            var queue = message.Event switch
            {
                ExecutionStartedEvent executionStarted => QueueMapper.ToQueueName(executionStarted.Name, executionStarted.Version),
                SubOrchestrationInstanceCompletedEvent => parentOrchestrationQueue,
                SubOrchestrationInstanceFailedEvent => parentOrchestrationQueue,
                _ => orchestrationQueue
            };

            return new OrchestrationMessage
            {
                Id = Guid.NewGuid(),
                InstanceId = message.OrchestrationInstance.InstanceId,
                ExecutionId = message.OrchestrationInstance.ExecutionId,
                Queue = queue,
                SequenceNumber = sequence,
                AvailableAt = message.Event is TimerFiredEvent timerFiredEvent
                    ? timerFiredEvent.FireAt.ToUniversalTime()
                    : DateTime.UtcNow,
                Message = _options.DataConverter.Serialize(message),
            };
        }
    }
}
