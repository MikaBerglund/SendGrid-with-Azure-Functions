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

namespace SendGridFunctions
{
    public class SendGridFunctions
    {
        public SendGridFunctions(EmailService email)
        {
            this.Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        private EmailService Email;

        [FunctionName(Names.SendEmailWithTemplateHttp)]
        public async Task<HttpResponseMessage> SendEmailWithTemplateHttp([HttpTrigger(AuthorizationLevel.Function, "POST")]HttpRequestMessage request)
        {

            return new HttpResponseMessage(HttpStatusCode.NotImplemented);
        }
    }
}
