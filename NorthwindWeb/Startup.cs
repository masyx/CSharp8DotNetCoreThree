﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
using Microsoft.EntityFrameworkCore;
using Packt.Shared;
using static System.Console;

namespace NorthwindWeb
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            //C:\Users\Sergey\source\repos\CSharp8DotNetCoreThree\NorthwindContextLib\Northwind.db
            string databasePath = Path.Combine("..", "NorthwindContextLib\\Northwind.db");
            services.AddDbContext<Northwind>(option => option.UseSqlite($"Data Source={databasePath}"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();
            app.Use(async(HttpContext context, Func<Task> next) =>
            {
                var rep = context.GetEndpoint() as RouteEndpoint;
                if (rep != null)
                {
                    WriteLine($"Endpoint name: {rep.DisplayName}");
                    WriteLine($"Endpoint route pattern: {rep.RoutePattern.RawText}");
                }

                if(context.Request.Path == "/bonjour")
                {
                    await context.Response.WriteAsync("Bon appetite!");
                    return;
                }

                await next();
            });
            app.UseHttpsRedirection();

            app.UseDefaultFiles(); // index.html, default.html, and so on
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                endpoints.MapGet("/hello", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
