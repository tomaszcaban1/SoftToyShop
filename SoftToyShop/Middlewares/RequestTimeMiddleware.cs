﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SoftToyShop.Constants;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SoftToyShop.Middlewares
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeMiddleware> _logger;
        private Stopwatch _stopWatch;

        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _stopWatch = new Stopwatch();
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopWatch.Start();
            await next.Invoke(context);
            _stopWatch.Stop();

            var elapsedSeconds = _stopWatch.Elapsed.TotalSeconds;
            if(elapsedSeconds > RequestTime.requestTimeExecutionSecWarning)
            {
                var message = $"Request [{context.Request.Method}] at {context.Request.Path} " +
                    $"took {elapsedSeconds} s";

                _logger.LogInformation(message);
            }
        }
    }
}
