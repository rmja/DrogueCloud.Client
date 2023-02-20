using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;

namespace DrogueCloud.Client
{
    public class BasicAuthHandler<TOptions> : DelegatingHandler where TOptions : class, IApiCredentials
    {
        private readonly TOptions _options;

        public BasicAuthHandler(IOptions<TOptions> options)
        {
            _options = options.Value;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Headers.Authorization is null)
            {
                var basic = Convert.ToBase64String(Encoding.ASCII.GetBytes(_options.Username + ":" + _options.Password));
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", basic);
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
