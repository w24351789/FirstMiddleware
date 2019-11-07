using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace middleware
{
    public class Startup
    {
      
        public void Configure(IApplicationBuilder app)
        {
            //First Middleware
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("First Middleware in \r\n");
                await next.Invoke();
                await context.Response.WriteAsync("First Middleware out \r\n");
            });

            //Second Middleware
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Second Middleware in \r\n");
                await next.Invoke();
                await context.Response.WriteAsync("Second Middleware out \r\n");
            });
            //Map
            app.Map("/second", mapApp =>
            {
                mapApp.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync("Map in /second Middleware in \r\n");
                    await next.Invoke();
                    await context.Response.WriteAsync("Map in /second Middleware out \r\n");
                });

                mapApp.Run(async context =>
                {
                    await context.Response.WriteAsync("Map in /second Middleware run \r\n");
                });
            });
            //Third Middleware
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Third Middleware in \r\n");
                await next.Invoke();
                await context.Response.WriteAsync("Third Middleware out \r\n");
            });

            //app run
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello here is app run() \r\n");
            });
        }
    }
}
