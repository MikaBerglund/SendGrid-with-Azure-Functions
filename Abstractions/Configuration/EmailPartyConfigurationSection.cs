using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.Configuration
{
    /// <summary>
    /// Defines an e-mail recipient or sender.
    /// </summary>
    public class EmailPartyConfigurationSection
    {
        /// <summary>
        /// The e-mail address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The display name.
        /// </summary>
        public string Name { get; set; }

    }
}
