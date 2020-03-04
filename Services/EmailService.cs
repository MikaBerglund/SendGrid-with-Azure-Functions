using Abstractions.Configuration;
using Abstractions.Messaging;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// A service implementation that uses SendGrid to send e-mails with.
    /// </summary>
    public class EmailService
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="config">The configuration required by the service implementation.</param>
        public EmailService(SendGridConfigurationSection config)
        {
            this.Config = config ?? throw new ArgumentNullException(nameof(config));
        }

        private SendGridConfigurationSection Config;



        /// <summary>
        /// Sends an e-mail using a template as specified in <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The request containing all necessary data for sending an e-mail.</param>
        /// <remarks>
        /// <para>
        /// The parameters that have a default value of <c>null</c> are optional. The rest are required.
        /// </para>
        /// <para>
        /// If the culture is specified in the request, and the configuration contains an alternative template for
        /// the specified template with the specified culture, that template is used instead.
        /// </para>
        /// </remarks>
        public async Task SendEmailWithTemplateAsync(SendEmailWithTemplateRequest request)
        {
            var templateId = this.ResolveTemplateId(request.TemplateId, request.Culture);

            var msg = new SendGridMessage
            {
                Personalizations = new List<Personalization>(),
                TemplateId = templateId,
                From = new EmailAddress(request.From ?? this.Config?.DefaultSender?.Address, request.FromName ?? this.Config?.DefaultSender?.Name)
            };

            msg.Personalizations.Add(new Personalization
            {
                TemplateData = request.TemplateData ?? new Dictionary<string, string>(),
                Tos = new List<EmailAddress>
                {
                    new EmailAddress(request.To, request.ToName)
                }
            });

            var client = new SendGridClient(this.Config.ApiKey);
            var response = await client.SendEmailAsync(msg);
            if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                // The e-mail was not sent, so we need to report that with an exception.
                var body = await response.Body.ReadAsStringAsync();
                throw new System.Net.Http.HttpRequestException($"The SendGrid API returned status code: {response.StatusCode}. Detailed response body: {body}");
            }
        }



        private string ResolveTemplateId(string defaultTemplateId, CultureInfo culture)
        {
            var tpl = this.Config.Templates?.First(x => x.TemplateId == defaultTemplateId);
            return this.ResolveTemplateId(defaultTemplateId, tpl?.Localized ?? new List<LocalizedEmailTemplateConfigurationSection>(), culture);
        }

        private string ResolveTemplateId(string defaultTemplateId, ICollection<LocalizedEmailTemplateConfigurationSection> alternatives, CultureInfo culture)
        {
            string templateId = null;

            var c = culture;

            while(string.IsNullOrEmpty(templateId) && !string.IsNullOrEmpty(c?.Name))
            {
                var tpl = alternatives.FirstOrDefault(x => x.Culture?.ToLower() == c.Name?.ToLower());
                templateId = tpl?.TemplateId;

                c = c?.Parent;
            }

            return templateId ?? defaultTemplateId;
        }
    }
}
