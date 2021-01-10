﻿using System;
using DurableTask.Core;
using LLL.DurableTask.Worker;
using LLL.DurableTask.Worker.Attributes;
using Microsoft.Extensions.Logging;

namespace CarWorker.Activities
{
    [Activity(Name = "BookCar", Version = "v1")]
    public class BookCarActivity : ActivityBase<BookCarInput, BookCarResult>
    {
        private readonly ILogger<BookCarActivity> _logger;

        public BookCarActivity(ILogger<BookCarActivity> logger)
        {
            _logger = logger;
        }

        protected override BookCarResult Execute(TaskContext context, BookCarInput input)
        {
            var bookingId = Guid.NewGuid();

            _logger.LogInformation("Booking car {bookingId}", bookingId);

            return new BookCarResult
            {
                BookingId = bookingId
            };
        }
    }

    public class BookCarInput
    {
    }

    public class BookCarResult
    {
        public Guid BookingId { get; set; }
    }
}
