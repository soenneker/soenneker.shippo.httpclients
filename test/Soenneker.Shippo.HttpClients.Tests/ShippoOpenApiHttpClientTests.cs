using Soenneker.Shippo.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Shippo.HttpClients.Tests;

[Collection("Collection")]
public sealed class ShippoOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly IShippoOpenApiHttpClient _httpclient;

    public ShippoOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IShippoOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
