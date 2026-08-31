[![](https://img.shields.io/nuget/v/soenneker.shippo.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.shippo.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.shippo.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.shippo.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.shippo.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.shippo.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.shippo.httpclients/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.shippo.httpclients/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Shippo.HttpClients

Provides a reusable `HttpClient` configured with Shippo's API base address and token authentication.

## Installation

```bash
dotnet add package Soenneker.Shippo.HttpClients
```

## Configuration

```json
{
  "Shippo": {
    "ApiKey": "your-shippo-token"
  }
}
```

`Shippo:ClientBaseUrl`, `Shippo:AuthHeaderName`, and `Shippo:AuthHeaderValueTemplate` can override the defaults when needed. The value template must contain `{token}`.

## Usage

```csharp
using Soenneker.Shippo.HttpClients.Abstract;
using Soenneker.Shippo.HttpClients.Registrars;

services.AddShippoOpenApiHttpClientAsSingleton();

public sealed class ShippoRequestSender
{
    private readonly IShippoOpenApiHttpClient _shippo;

    public ShippoRequestSender(IShippoOpenApiHttpClient shippo)
    {
        _shippo = shippo;
    }

    public async Task<HttpResponseMessage> GetCarrierAccounts(CancellationToken cancellationToken)
    {
        HttpClient client = await _shippo.Get(cancellationToken);
        return await client.GetAsync("carrier_accounts", cancellationToken);
    }
}
```

The provider owns the cached `HttpClient`; disposing the provider removes and disposes that client. Scoped registration creates an independently owned client for each scope.
