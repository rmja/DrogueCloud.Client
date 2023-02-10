using DrogueCloud.Client;
using Microsoft.Extensions.Options;
using Refit;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DrogueCloudExtensions
    {
        public static IHttpClientBuilder AddDrogueCloud(this IServiceCollection services, Action<DrogueCloudOptions>? configureOptions = null)
        {
            if (configureOptions is not null)
            {
                services.Configure(configureOptions);
            }

            return services
                .AddTransient<BasicAuthHandler>()
                .AddRefitClient<IDrogueCloudApi>()
                    .ConfigureHttpClient((services, client) =>
                    {
                        var endpoint = services.GetRequiredService<IOptions<DrogueCloudOptions>>().Value.Endpoint;
                        client.BaseAddress = new Uri(endpoint);
                    })
                    .AddHttpMessageHandler<BasicAuthHandler>();
        }
    }
}
