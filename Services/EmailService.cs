using Abstractions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class EmailService
    {

        public EmailService(SendGridConfigurationSection config)
        {
            this.Config = config ?? throw new ArgumentNullException(nameof(config));
        }

        private SendGridConfigurationSection Config;

    }
}
