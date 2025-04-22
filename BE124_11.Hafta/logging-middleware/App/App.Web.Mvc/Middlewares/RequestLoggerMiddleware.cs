using Microsoft.Extensions.Logging;

namespace App.Web.Mvc.Middlewares
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggerMiddleware> _logger;

        public RequestLoggerMiddleware(RequestDelegate next, ILogger<RequestLoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);

                _logger.LogInformation("{tarih} - {path} adresine {method} isteğinde bulunuldu.", DateTime.Now, context.Request.Path, context.Request.Method);

                if (context.Response.StatusCode < 500 && context.Response.StatusCode >= 400)
                {
                    _logger.LogWarning("{tarih} - {path} adresi {statusCode} cevabı verdi.", DateTime.Now, context.Request.Path, context.Response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Bir hata oluştu.");
                throw;
            }
        }
       


    }
}
