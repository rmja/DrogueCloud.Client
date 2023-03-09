using DrogueCloud.Client;
using Microsoft.Extensions.Options;
using Refit;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DrogueCloudExtensions
    {
        public static IHttpClientBuilder AddDrogueCloudManagementApi(this IServiceCollection services, Action<DrogueCloudManagementApiOptions>? configureOptions = null)
        {
            if (configureOptions is not null)
            {
                services.Configure(configureOptions);
            }

            return services
                .AddTransient<BasicAuthHandler<DrogueCloudManagementApiOptions>>()
                .AddRefitClient<IDrogueCloudManagementApi>()
                    .ConfigureHttpClient((services, client) =>
                    {
                        var endpoint = services.GetRequiredService<IOptions<DrogueCloudManagementApiOptions>>().Value.Endpoint;
                        client.BaseAddress = new Uri(endpoint);
                    })
                    .AddHttpMessageHandler<BasicAuthHandler<DrogueCloudManagementApiOptions>>();
        }

        public static IHttpClientBuilder AddDrogueCloudDeviceApi(this IServiceCollection services, Action<DrogueCloudDeviceApiOptions>? configureOptions = null)
        {
            if (configureOptions is not null)
            {
                services.Configure(configureOptions);
            }

            return services
                .AddTransient<BasicAuthHandler<DrogueCloudDeviceApiOptions>>()
                .AddRefitClient<IDrogueCloudDeviceApi>()
                    .ConfigureHttpClient((services, client) =>
                    {
                        var endpoint = services.GetRequiredService<IOptions<DrogueCloudDeviceApiOptions>>().Value.Endpoint;
                        client.BaseAddress = new Uri(endpoint);
                    })
                    .AddHttpMessageHandler<BasicAuthHandler<DrogueCloudDeviceApiOptions>>();
        }
    }
}
