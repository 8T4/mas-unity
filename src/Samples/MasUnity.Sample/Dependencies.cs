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
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Api", Version = "v1"});
                c.UseInlineDefinitionsForEnums();
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