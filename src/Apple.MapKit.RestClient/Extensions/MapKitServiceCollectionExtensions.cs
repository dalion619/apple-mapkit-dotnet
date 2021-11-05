using System;
using Apple.MapKit.RestClient.Interfaces;
using Apple.MapKit.RestClient.Options;
using Apple.MapKit.RestClient.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Apple.MapKit.RestClient.Extensions
{
    /// <summary>
    ///     Adds the Apple MapKit JS REST Client service to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <param name="setupAction">
    ///     An <see cref="Action{T}" /> to configure the provided. <see cref="MapKitOptions" />
    /// </param>
    /// <returns>The <see cref="IServiceCollection" /> so that additional calls can be chained.</returns>
    public static class MapKitServiceCollectionExtensions
    {
        public static IServiceCollection AddMapKitService(this IServiceCollection services,
            Action<MapKitOptions>
                setupAction)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            if (setupAction == null) throw new ArgumentNullException(nameof(setupAction));

            services.AddOptions();
            services.Configure(setupAction);
            services.Add(ServiceDescriptor.Singleton<IMapKitClient, MapKitClient>());

            return services;
        }
    }
}