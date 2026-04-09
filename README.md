# TurkeySMS C# SDK (Official) 🔷

[![NuGet Version](https://img.shields.io/nuget/v/TurkeySms.svg)](https://www.nuget.org/packages/TurkeySms/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Official C# SDK for the **TurkeySMS API V4**. High-performance, asynchronous client for .NET applications.

## 🛠 Installation

Install via NuGet Package Manager:

```bash
Install-Package TurkeySms
```

Or via .NET CLI:

```bash
dotnet add package TurkeySms
```

---

## 🚀 Quick Start

### Initialize Client

```csharp
using TurkeySms;

var client = new TurkeySmsClient("your_api_key_here");
```

### Sending Standard SMS

```csharp
var response = await client.SendSmsAsync("SENDER", "905xxxxxxxxx", "Hello from C#!");
Console.WriteLine(response);
```

### Sending OTP SMS

```csharp
var response = await client.SendOtpAsync("905xxxxxxxxx", 1, 4);
```

### Advanced OTP (Custom Text)

```csharp
var response = await client.SendDetailedOtpAsync("SENDER", "905xxxxxxxxx", "Code: TS-CODE", 1);
```

### Check Balance

```csharp
var balance = await client.GetBalanceAsync();
Console.WriteLine($"Current Balance: {balance}");
```

---

## 🛡 Security

For security reporting, contact support@turkeysms.com.tr.

## 📄 License

The MIT License (MIT). Please see [License File](LICENSE.md) for more information.

---
© 2026 **TurkeySMS Bilişim ve İletişيم Hizmetleri Tic. Ltd. Şti.**
