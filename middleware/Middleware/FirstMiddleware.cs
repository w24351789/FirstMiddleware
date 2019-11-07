
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace middleware.Middleware
{
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;
        public FirstMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("First Middleware Invoke in \r\n");
            await _next(context);
            await context.Response.WriteAsync("First Middleware Invoke out \r\n");
        }
    }
}
