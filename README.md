# Zenmoney.NET
This project hosts the .NET client library for the [Zenmoney API](https://github.com/zenmoney/ZenPlugins/wiki/ZenMoney-API).

## Supported Frameworks
.NET Standard 2.1

## Installation
* Package Manager
```powershell
Install-Package Zenmoney -Version 1.0.0
```
* .NET CLI
```code
dotnet add package Zenmoney --version 1.0.0
```
* Package Reference
```xml
<PackageReference Include="Zenmoney" Version="1.0.0" />
```

## Usage
**Get updates for the last 7 days**
```csharp
var client = new Client(new HttpClient(), new NewtonsoftSerializer());

var token = "YOUR_ACCESS_TOKEN";
var currentTimestamp = (int) DateTimeOffset.UtcNow.ToUnixTimeSeconds();
var lastTimestamp = (int) DateTimeOffset.UtcNow.AddDays(-7).ToUnixTimeSeconds();
var request = new Request(token, currentTimestamp, lastTimestamp);

var result = await client.Sync(request);

// Getting some entities
result.Transaction
result.Account
// etc...
```
**Create entity (for example account)**
```csharp
var client = new Client(new HttpClient(), new NewtonsoftSerializer());

var token = "YOUR_ACCESS_TOKEN";
var currentTimestamp = (int) DateTimeOffset.UtcNow.ToUnixTimeSeconds();
var request = new Request(token, currentTimestamp, currentTimestamp);

var account = new Account
{
    Balance = 1000,
    Title = "My Account",
    Type = Account.AccountType.Ccard,
    Id = Guid.NewGuid().ToString(),
    Changed = DateTime.Now,
    Instrument = 1,
};
request.Account.Add(account);

await client.Sync(request);
```
