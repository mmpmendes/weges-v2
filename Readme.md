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
# How to generate migrations sql script
### 1 - Navigate to the BaseDbMigrations project

### 2 - Generate migrations sql script for IdentityMigrations project
```
dotnet ef migrations script --project ..\IdentityMigrations\IdentityMigrations.csproj --output migration.sql --context=UtilizadoresDbContext
```
### 3 - Generate migrations sql script for BaseDbMigrations project
```
 dotnet ef migrations script --output weges_migration.sql --context=WegesDbContext
```