using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.Configuration
{
    /// <summary>
    /// Connects a template with a culture.
    /// </summary>
    public class LocalizedEmailTemplateConfigurationSection
    {
        /// <summary>
        /// The ID of the template.
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// The string representation 
        /// </summary>
        public string Culture { get; set; }
    }
}
