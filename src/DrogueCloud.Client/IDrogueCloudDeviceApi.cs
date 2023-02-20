using Refit;

namespace DrogueCloud.Client
{
    public interface IDrogueCloudDeviceApi
    {
        [Post("/v1/{channel}")]
        Task PublishAsync(string channel, HttpContent content, string? application = null, string? device = null, string? @as = null, [Header("Authorization")] string? authorization = null, CancellationToken cancellationToken = default);
    }
}
