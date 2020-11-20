using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using GraphQLDemo.DAL;
using GraphQLDemo.Interfaces.Repository;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace GraphQLDemo.API
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
            services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
                options.Filters.Add(new ConsumesAttribute("application/json"));
                options.Filters.Add(new ProducesAttribute("application/json"));
                options.Filters.Add(new ProducesResponseTypeAttribute(Status500InternalServerError));
            });

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "LibraryOpenAPISpecification",
                    new OpenApiInfo
                    {
                        Title = "Cricinfo.API - Documentation",
                        Version ="1.0.0"// Configuration["APIVersion"]
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                setupAction.IncludeXmlComments(xmlPath);

                setupAction.UseInlineDefinitionsForEnums();
            });

            services.AddScoped<IBikeStoreRepository>(_ =>
                    new BikeStoreRepository(Configuration.GetConnectionString("AzureDBConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/LibraryOpenAPISpecification/swagger.json", "Documentation");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
