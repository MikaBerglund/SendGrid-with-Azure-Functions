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
            var config = serviceProvider.GetService<IConfiguration>();
            var rootConfig = config.Get<RootConfigurationSection>();

            services.AddSingleton(rootConfig);
            services.AddSingleton(rootConfig.SendGrid);
            services.AddSingleton<EmailService>();
        }
    }
}
