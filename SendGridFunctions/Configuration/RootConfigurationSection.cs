using Abstractions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SendGridFunctions.Configuration
{
    public class RootConfigurationSection
    {

        public string AzureWebJobsStorage { get; set; }

        public SendGridConfigurationSection SendGrid { get; set; }

    }
}
