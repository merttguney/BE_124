using System.Diagnostics;

namespace App.Web.Mvc.Middlewares
{
    public class ExampleMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExampleMiddleware> _logger;

        public ExampleMiddleware(RequestDelegate next, ILogger<ExampleMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                Stopwatch sw = new();

                sw.Start();

                await _next(context);

                sw.Stop();

                var durationMs = sw.ElapsedMilliseconds;


                if (context.Response.StatusCode >= 400 && context.Response.StatusCode < 500)
                {
                    _logger.LogWarning("warning : {method} - {path} | ms : {duration}", context.Request.Method, context.Request.Path, durationMs);
                }
                if (context.Response.StatusCode >= 500)
                {
                    _logger.LogError("error : {method} - {path} | ms : {duration} ", context.Request.Method, context.Request.Path, durationMs);
                }

                _logger.LogInformation("info : {method} - {path} | ms : {duration} ", context.Request.Method, context.Request.Path, durationMs);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Bir hata oluştu.");
                throw;
            }

         
        }

    }
}
