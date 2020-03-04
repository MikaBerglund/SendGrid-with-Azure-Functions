Application Settings
====================

To be able to run this Functions application locally, you need to have a `local.settings.json` in the same directory with this documentation. The contents of that file should be:

``` JSON
{
  "IsEncrypted": false,
  "Values": {
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    
    "SendGrid:ApiKey": string,
    "SendGrid:DefaultSender:Address": string,
    "SendGrid:DefaultSender:Name": string,
    
    "SendGrid:Templates:0:TemplateId": string,
    "SendGrid:Templates:0:Localized:0:TemplateId": string,
    "SendGrid:Templates:0:Localized:0:Culture": string,
    "SendGrid:Templates:0:Localized:nn:TemplateId": string,
    "SendGrid:Templates:0:Localized:nn:Culture": string,
    
    ...
    
    "SendGrid:Templates:n:TemplateId": string,
    "SendGrid:Templates:n:Localized:0:TemplateId": string,
    "SendGrid:Templates:n:Localized:0:Culture": string,
    "SendGrid:Templates:n:Localized:nn:TemplateId": string,
    "SendGrid:Templates:n:Localized:nn:Culture": string
  }
}
```


Required
--------
The following settings are required. The application will not work properly without properly configuring these.

- `SendGrid:ApiKey`: Your SendGrid API key.
- `SendGrid:DefaultSender:Address`: The e-mail address to use as sender by default, if no other address is specified when sending.

Optional
--------
The following settings are optional.

- `SendGrid:DefaultSender:Name`: The display name for the default sender.
- `SendGrid:Templates:0:TemplateId`: The default ID for a template. Configuring templates is only required if you want to configure culture specific alternatives for a given template.
- `SendGrid:Templates:0:Localized:0:TemplateId`: The ID of the template that acts as a localized version of the default template specified above.
- `SendGrid:Templates:0:Localized:0:Culture`: The culture, for instance `fi-FI` or `de` for the template specified in the previous setting.
- `SendGrid:Templates:0:Localized:nn:TemplateId`: Repeat the two previous settings for every culture variant you want to have. Remember to increment the `nn` index so that you specify both `TemplateId` and `Culture` with the same index.
- `SendGrid:Templates:0:Localized:nn:Culture`: The culture for the `nn` template.

The following settings you then just repeat for every template you want to configure with culture specific variants.
- `SendGrid:Templates:n:TemplateId`
- `SendGrid:Templates:n:Localized:0:TemplateId`
- `SendGrid:Templates:n:Localized:0:Culture`
- `SendGrid:Templates:n:Localized:nn:TemplateId`
- `SendGrid:Templates:n:Localized:nn:Culture`


Configuration in Azure
----------------------
To configure your functions applicaiton in Azure, you use the same key-value pairs as above.