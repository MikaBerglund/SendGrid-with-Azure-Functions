using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.Configuration
{
    /// <summary>
    /// Configuration for SendGrid.
    /// </summary>
    public class SendGridConfigurationSection
    {
        /// <summary>
        /// The SendGrid API key.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Default sender information, if not specified for each e-mail separately when sending.
        /// </summary>
        public EmailPartyConfigurationSection DefaultSender { get; set; }

    }
}
