using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.Configuration
{
    /// <summary>
    /// Configuration for an e-mail template.
    /// </summary>
    public class EmailTemplateConfigurationSection
    {
        /// <summary>
        /// The ID of the template.
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// A collection of localized alternatives for this template.
        /// </summary>
        public ICollection<LocalizedEmailTemplateConfigurationSection> Localized { get; set; }
    }
}
