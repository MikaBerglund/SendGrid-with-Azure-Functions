using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using SendGridFunctions;
using SendGridFunctions.Configuration;
using Services;

[assembly: WebJobsStartup(typeof(Startup))]

namespace SendGridFunctions
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            var services = builder.Services;
            var serviceProvider = services.BuildServiceProvider();

            //--------------------------------------------------------------------------
            // Load in the configuration and add selected types as services to leverage
            // DI for services depending on configuration.
            var config = serviceProvider.GetService<IConfiguration>();
            var rootConfig = config.Get<RootConfigurationSection>();
            services.AddSingleton(rootConfig);
            services.AddSingleton(rootConfig.SendGrid);
            //--------------------------------------------------------------------------


            // Add a service implementation for working with SendGrid.
            services.AddSingleton<EmailService>();

        }
    }
}
