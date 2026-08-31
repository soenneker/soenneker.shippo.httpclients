using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Shippo.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Shippo.HttpClients.Registrars;

/// <summary>
/// Registers the authenticated Shippo HTTP client provider.
/// </summary>
public static class ShippoOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds the Shippo HTTP client provider as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddShippoOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IShippoOpenApiHttpClient, ShippoOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds the Shippo HTTP client provider as a scoped service. Each scope owns a separate cached HTTP client. <para/>
    /// </summary>
    public static IServiceCollection AddShippoOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IShippoOpenApiHttpClient, ShippoOpenApiHttpClient>();

        return services;
    }
}
