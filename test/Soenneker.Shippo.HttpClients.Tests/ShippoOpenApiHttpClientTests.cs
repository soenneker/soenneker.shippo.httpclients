using Soenneker.Shippo.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Shippo.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class ShippoOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IShippoOpenApiHttpClient _httpclient;

    public ShippoOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IShippoOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
