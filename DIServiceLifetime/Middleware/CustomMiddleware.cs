using DIServiceLifetime.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIServiceLifetime.Middleware
{
    public class CustomMiddleware
    {
        private readonly ISingleton _singleton;
        private readonly RequestDelegate _next;
        public CustomMiddleware(RequestDelegate next, ISingleton singleton)
        {
            _singleton = singleton;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ITransient transient, IScoped scoped)
        {
            var output = new List<string>();
            Console.WriteLine("Middleware Request");
            transient.Info();
            scoped.Info();
            _singleton.Info();
            _next(httpContext);
        }
    }
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware>();
        }
    }
}
