using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthChecks.UI.Client;
using MasUnity.HealthCheck.Configuration;
using MasUnity.HostedService.Configuration;
using MasUnity.Sample.Agents.EvenOdd;
using MasUnity.Sample.Agents.EvenOdd.Actions;
using MasUnity.Sample.Agents.EvenOdd.Knowledges;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MasUnity.Sample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureMasUnity((option) =>
            {
                services.AddSingleton<OddOrEvenRecognition>();

                option.AddAgent<EvenAgent>()
                    .WithHealtCheck()
                    .WithAction<SayNumberIsEven>();
                
                option.AddAgent<OddAgent>()
                    .WithHealtCheck()
                    .WithAction<SayNumberIsOdd>();                
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