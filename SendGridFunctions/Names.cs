using System;
using System.Collections.Generic;
using System.Text;
using Abstractions.Messaging;

namespace SendGridFunctions
{
    internal static class Names
    {

        /// <summary>
        /// The HTTP triggered (POST) function that is used to send an e-mail with SendGrid using a defined template.
        /// </summary>
        /// <remarks>
        /// The request to this function supports the following query string parameters.
        /// <list type="table">
        /// <item>
        /// <term>templateid</term>
        /// <description>Required. The ID of the SendGrid template to send the e-mail with.</description>
        /// </item>
        /// <item>
        /// <term>culture</term>
        /// <description>
        /// Optional. A culture (such as fi-FI) to use when selecting a template. If an alternative template is not 
        /// found for the template specified in <c>templateid</c> with the given culture, the e-mail will be sent 
        /// with that specified template.
        /// </description>
        /// </item>
        /// <item>
        /// <term>to</term>
        /// <description>Required. The e-mail address to send the e-mail to.</description>
        /// </item>
        /// <item>
        /// <term>toname</term>
        /// <description>Optional. A display name for the recipient. If not specified, only <c>email</c> is used.</description>
        /// </item>
        /// <item>
        /// <term>from</term>
        /// <description>Optrional. The e-mail address to send the message from.</description>
        /// </item>
        /// <item>
        /// <term>fromname</term>
        /// <description>Optional. The display name of the sender.</description>
        /// </item>
        /// </list>
        /// In addition to these query string parameters, the POST body is assumed to contain a JSON document where each field
        /// represents a placeholder in the template, and the field value represents the value that will be injected into
        /// the template when sending.
        /// </remarks>
        public const string SendEmailWithTemplateHttp = nameof(SendEmailWithTemplateHttp);


        /// <summary>
        /// The orchestration function that sends an e-mail using a template. The input to the function must be an instance of the <see cref="SendEmailWithTemplateRequest"/>
        /// </summary>
        public const string SendEmailWithTemplateOrch = nameof(SendEmailWithTemplateOrch);

        /// <summary>
        /// The activity function that sends an e-mail using a template. The input to the function must be an instance of the <see cref="SendEmailWithTemplateRequest"/>
        /// </summary>
        public const string SendEmailWithTemplate = nameof(SendEmailWithTemplate);

    }
}
