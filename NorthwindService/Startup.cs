using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using NorthwindService.Repositories;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace NorthwindService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //C:\Users\Sergey\source\repos\CSharp8DotNetCoreThree\NorthwindContextLib\Northwind.db
            string databasePath = Path.Combine("..", "NorthwindContextLib\\Northwind.db");
            services.AddDbContext<Northwind>(option => option.UseSqlite($"Data Source={databasePath}"));

            services.AddControllers(options =>
            {
                Console.WriteLine("Default output formatters:");
                foreach (IOutputFormatter formatter in options.OutputFormatters)
                {
                    var mediaFormatter = formatter as OutputFormatter;
                    if (mediaFormatter == null)
                    {
                        Console.WriteLine($" {formatter.GetType().Name}");
                    }
                    else // OutputFormatter class has SupportedMediaTypes
                    {
                        Console.WriteLine(" {0}, Media types: {1}",
                        arg0: mediaFormatter.GetType().Name,
                        arg1: string.Join(", ",
                        mediaFormatter.SupportedMediaTypes));
                    }
                }
            })
            .AddXmlDataContractSerializerFormatters()
            .AddXmlSerializerFormatters()
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", info: new OpenApiInfo { Title = "NorthwindService API", Version = "v1" });
            });

            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "NorthwindService API version v1");

                    c.SupportedSubmitMethods(new[]
                    {
                        SubmitMethod.Get,
                        SubmitMethod.Post,
                        SubmitMethod.Put,
                        SubmitMethod.Delete
                    });
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
