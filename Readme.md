# Initial Setup

### Define default admin user in the appsettings for the web app
```
{
  "adminEmail": "<admin@email",
  "adminPassword": "<admin-password>",
  "EmailConfiguracoes": {
    "Email": "<email-placeholder>",
    "Name": "WEGES",
    "UserName": "<email-placeholder>",
    "Password": "<email-password>",
    "Host": "<host>",
    "Port": 111,
    "UseSSL": true,
    "DefaultSubject": "WEGES - Comunicação"
  },
  "EmailTemplates": {
    "ConfirmacaoEmailTemplate": "..\\EmailTemplates\\ConfirmacaoEmailTemplate.htm"
  }
}
```
