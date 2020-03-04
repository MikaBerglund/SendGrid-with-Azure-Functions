using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Abstractions.Messaging
{
    /// <summary>
    /// Represents a request to send an e-mail using a template.
    /// </summary>
    public class SendEmailWithTemplateRequest
    {

        /// <summary>
        /// The ID of the template to send.
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// A dictionary containing name-value pairs containing data that will be injected into placeholders in the template.
        /// </summary>
        public Dictionary<string, string> TemplateData { get; set; }

        /// <summary>
        /// The e-mail address of the recipient.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// The display name of the recipient. If not specified, the e-mail is sent with e-mail address only.
        /// </summary>
        public string ToName { get; set; }

        /// <summary>
        /// The e-mail address of the sender. If not specified, it is resolved from configuration.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// The display name of the sender. If not specified, the name is resolved from configuration.
        /// </summary>
        public string FromName { get; set; }

        /// <summary>
        /// The culture specifying an alternative version for the template specified in <see cref="TemplateId"/>.
        /// If not specified,  or an alternative version is not found matching the given culture, the template specified
        /// in <see cref="TemplateId"/> is used as fallback.
        /// </summary>
        public CultureInfo Culture { get; set; }

    }
}
