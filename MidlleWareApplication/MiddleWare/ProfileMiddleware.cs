using System.Diagnostics;

namespace MidlleWareApplication.MiddleWare
{
    public class ProfileMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ProfileMiddleware> _logger;
        public ProfileMiddleware(RequestDelegate next,ILogger<ProfileMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await _next(context);
            stopwatch.Stop();
            _logger.LogInformation($"Request '{context.Request.Path}' Took '{stopwatch.ElapsedMilliseconds}'Ms to execute");
        }
    }
}
