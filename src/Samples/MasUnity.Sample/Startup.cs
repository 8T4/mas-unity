using MasUnity.HealthCheck.Configuration;
using MasUnity.HostedService.Configuration;
using MasUnity.Sample.Agents.EvenOdd;
using MasUnity.Sample.Agents.EvenOdd.Actions;
using MasUnity.Sample.Agents.EvenOdd.Knowledges;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MasUnity.Sample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureMasUnity((option) =>
            {
                option.AddAgent<EvenAgent>(2)
                    .WithHealtCheck()
                    .WithKnowledge<EvenOrOddRecognition>()
                    .WithSchedule<EvenOrOddAgentSchedule>()
                    .WithAction<SayNumberIsEven>()
                    .Build();
                
                option.AddAgent<OddAgent>(2)
                    .WithHealtCheck()
                    .WithKnowledge<EvenOrOddRecognition>()
                    .WithSchedule<EvenOrOddAgentSchedule>()
                    .WithAction<SayNumberIsOdd>()
                    .Build();
            });
            
            services.AddSwaggerServices();
            services.AddHealthCheckServices();
            services.AddControllers();            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ConfigureSwagger();
            app.ConfigureHealthCheck();
            app.ConfigureEndpoints();
        }
    }
}