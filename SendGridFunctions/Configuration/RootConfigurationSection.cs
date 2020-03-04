using Abstractions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SendGridFunctions.Configuration
{
    /// <summary>
    /// The root configuration section for functions apps.
    /// </summary>
    public class RootConfigurationSection
    {
        /// <summary>
        /// The storage connection to use.
        /// </summary>
        public string AzureWebJobsStorage { get; set; }

        /// <summary>
        /// SendGrid configuration.
        /// </summary>
        public SendGridConfigurationSection SendGrid { get; set; }

    }
}
