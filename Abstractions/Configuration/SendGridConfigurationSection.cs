using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.Configuration
{
    public class SendGridConfigurationSection
    {
        public string ApiKey { get; set; }

        public EmailPartyConfigurationSection DefaultFrom { get; set; }

    }
}
