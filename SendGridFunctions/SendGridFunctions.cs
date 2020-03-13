using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using Services;
using System.Collections.Generic;
using Abstractions.Messaging;
using System.Globalization;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

namespace SendGridFunctions
{
    /// <summary>
    /// Functions for working with SendGrid.
    /// </summary>
    public class SendGridFunctions
    {
        public SendGridFunctions(EmailService email)
        {
            this.Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        private EmailService Email;

        /// <summary>
        /// See <see cref="Names.SendEmailWithTemplateHttp"/> for details on this function.
        /// </summary>
        [FunctionName(Names.SendEmailWithTemplateHttp)]
        public async Task<HttpResponseMessage> SendEmailWithTemplateHttp([HttpTrigger(AuthorizationLevel.Function, "POST")]HttpRequestMessage request,[DurableClient]IDurableClient client)
        {
            Dictionary<string, string> data = null;
            var json = await request.Content.ReadAsStringAsync();
            if(!string.IsNullOrEmpty(json))
            {
                data = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }

            var query = request.RequestUri.ParseQueryString();

            var culture = query.Get("culture");
            var sendRequest = new SendEmailWithTemplateRequest
            {
                From = query.Get("from"),
                FromName = query.Get("fromname"),
                TemplateData = data,
                TemplateId = query.Get("templateid"),
                To = query.Get("to"),
                ToName = query.Get("toname")
            };

            var instanceId = await client.StartNewAsync(Names.SendEmailWithTemplateOrch, sendRequest);
            return client.CreateCheckStatusResponse(request, instanceId);
        }

        /// <summary>
        /// See <see cref="Names.SendEmailWithTemplateOrch"/> for details on this function.
        /// </summary>
        [FunctionName(Names.SendEmailWithTemplateOrch)]
        public async Task SendEmailWithTemplateOrch([OrchestrationTrigger]IDurableOrchestrationContext context)
        {
            var request = context.GetInput<SendEmailWithTemplateRequest>();
            await context.CallActivityWithDefaultRetryAsync(Names.SendEmailWithTemplate, request);
        }

        /// <summary>
        /// See <see cref="Names.SendEmailWithTemplate"/> for details on this function.
        /// </summary>
        [FunctionName(Names.SendEmailWithTemplate)]
        public async Task SendEmailWithTemplate([ActivityTrigger]IDurableActivityContext context)
        {
            var request = context.GetInput<SendEmailWithTemplateRequest>();
            await this.Email.SendEmailWithTemplateAsync(request);
        }
    }
}
