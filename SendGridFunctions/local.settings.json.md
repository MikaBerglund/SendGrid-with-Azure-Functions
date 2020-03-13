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
    "SendGrid:DefaultSender:Name": string
  }
}
```


Settings
--------
The settings in the sample configuration above are:

- `SendGrid:ApiKey`: Required. Your SendGrid API key.
- `SendGrid:DefaultSender:Address`: Required. The e-mail address to use as sender by default, if no other address is specified when sending.
- `SendGrid:DefaultSender:Name`: Optional. The display name of the default sender.


Configuration in Azure
----------------------
To configure your functions applicaiton in Azure, you use the same key-value pairs as above.