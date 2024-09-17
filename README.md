## ⛔Never push sensitive information such as client id's, secrets or keys into repositories including in the README file⛔

# das-findapprenticeshiplegacy-api

<img src="https://avatars.githubusercontent.com/u/9841374?s=200&v=4" align="right" alt="UK Government logo">

![Build Status](https://sfa-gov-uk.visualstudio.com/Digital%20Apprenticeship%20Service/_apis/build/status%2FFind%20Apprenticeship%2Fdas-findapprenticeshiplegacy-api?repoName=SkillsFundingAgency%2Fdas-findapprenticeshiplegacy-api&branchName=main)

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=SkillsFundingAgency_das-findapprenticeshiplegacy-api&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=SkillsFundingAgency_das-findapprenticeshiplegacy-api)

[![License](https://img.shields.io/badge/license-MIT-lightgrey.svg?longCache=true&style=flat-square)](https://en.wikipedia.org/wiki/MIT_License)

## About

The das-findapprenticeshiplegacy-api (https://github.com/SkillsFundingAgency/das-findapprenticeshiplegacy-api) is the inner api for retrieving user's information from recruit's mongodb.

## 🚀 Installation

### Pre-Requisites
* A clone of this repository(https://github.com/SkillsFundingAgency/das-findapprenticeshiplegacy-api)
* A code editor that supports .NetCore 8 and above
* A storage emulator like Azurite (https://learn.microsoft.com/en-us/azure/storage/common/storage-use-emulator)
* An Azure Active Directory account with the appropriate roles as per the [das-employer-config repository](https://github.com/SkillsFundingAgency/das-employer-config/blob/master/das-findapprenticeshiplegacy-api/SFA.DAS.FindApprenticeshipsLegacy.Api.json)

### Config
You can find the latest config file in [das-employer-config repository](https://github.com/SkillsFundingAgency/das-employer-config/blob/master/das-findapprenticeshiplegacy-api/SFA.DAS.FindApprenticeshipsLegacy.Api.json)

* If you are using Azure Storage Emulator for local development purpose, then In your Azure Storage Account, create a table called Configuration and Add the following

ParitionKey: LOCAL
RowKey: SFA.DAS.FindApprenticeshipsLegacy.Api.json
Data:
```json
{
  "AzureAd": {
    "identifier": "https://{TENANT-NAME}/{IDENTIFIER}",
    "tenant": "{TENANT-NAME}"
  },
  "MongoConfiguration": {
    "AzureCosmosDb": "{{mongoConnectionString}}"
  },
  "UserAccountConfiguration": {
    "UserDirectorySecretKey": "secret"
  }
}
```

In the web project, if it does not exist already, add `AppSettings.Development.json` file with the following content:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConfigurationStorageConnectionString": "UseDevelopmentStorage=true",
  "ConfigNames": "SFA.DAS.FindApprenticeshipsLegacy.Api",
  "EnvironmentName": "LOCAL",
  "Version": "1.0"
}
```

## Technologies
* .NetCore 8.0
* Azure Storage Account
* MongoDb
* NUnit
* Moq
* FluentAssertions
* Azure App Insights
* MediatR

## How It Works

### Running

* Open command prompt and change directory to _**/src/SFA.DAS.FAA.Legacy.Api/**_
* Run the web project _**/src/SFA.DAS.FAA.Legacy.Api.csproj**_

MacOS
```
ASPNETCORE_ENVIRONMENT=Development dotnet run
```
Windows cmd
```
set ASPNETCORE_ENVIRONMENT=Development
dotnet run
```

### Application logs
Application logs are logged to [Application Insights](https://learn.microsoft.com/en-us/azure/azure-monitor/app/app-insights-overview) and can be viewed using [Azure Monitor](https://learn.microsoft.com/en-us/azure/azure-monitor/overview) at https://portal.azure.com

## Useful URLs

### Health check
https://localhost:7273/health - Endpoint to check the Mongo DB's connectivity health status

### Apprenticeship

https://localhost:7273/api/apprenticeship/{email} - Endpoint to get all the apprenticeships of a user by given email address

### User

https://localhost:7273/api/user/{email} - Endpoint to get user's information by given email address

https://localhost:7273/api/user/validate-credentials - Endpoint to validate user credentials

## 🐛 Known Issues

Nuget Package - MongoDB.Driver 2.13.0 contains vulnerabilities.


## License

Licensed under the [MIT license](LICENSE)
