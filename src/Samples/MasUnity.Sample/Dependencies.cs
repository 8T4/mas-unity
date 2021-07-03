using System;
using System.IO;
using System.Reflection;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MasUnity.Sample
{
    /// <summary>
    /// Inject Swagger
    /// </summary>
    public static partial class Dependencies
    {
        public static void AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MAS Unity API",
                    Version = "v1",
                    Description = "An API to perform MAS",
                    TermsOfService = new Uri("https://github.com/8T4/mas-unity"),
                    Contact = new OpenApiContact
                    {
                        Name = "Yan Justino",
                        Email = "contato@yanjustino.com",
                        Url = new Uri("https://www.linkedin.com/in/yanjustino/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MAS Unity API LICENSE",
                        Url = new Uri("https://github.com/8T4/mas-unity/blob/main/LICENSE"),
                    }
                });                
                c.UseInlineDefinitionsForEnums();
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);                
            });
        }
        
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            app.UseRouting();
        }
    }
    
    /// <summary>
    /// Inject Health Check
    /// </summary>
    public static partial class Dependencies
    {
        public static void AddHealthCheckServices(this IServiceCollection services)
        {
            services
                .AddHealthChecksUI()
                .AddInMemoryStorage();
        }

        public static void ConfigureHealthCheck(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/hc", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });            
            
            app.UseHealthChecksUI(config => config.UIPath = "/hc-ui");
        }
        
        public static void ConfigureEndpoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/hc");
                endpoints.MapHealthChecksUI();
            });
        }
    }
}