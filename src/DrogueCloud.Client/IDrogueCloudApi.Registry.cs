using DrogueCloud.Client.Models.Registry;
using Refit;

namespace DrogueCloud.Client
{
    public partial interface IDrogueCloudApi
    {
        [Get("/api/registry/v1alpha1/apps")]
        Task<List<App>> GetAppsAsync([Header("Authorization")] string? authorization = null, CancellationToken cancellationToken = default);

        [Get("/api/registry/v1alpha1/apps/{application}")]
        Task<App> GetAppAsync(string application, string? labels = null, int? limit = null, int? offset = null, [Header("Authorization")] string? authorization = null, CancellationToken cancellationToken = default);

        [Get("/api/registry/v1alpha1/apps/{application}/devices")]
        Task<List<Device>> GetDevicesAsync(string application, string? labels = null, int? limit = null, int? offset = null, [Header("Authorization")] string? authorization = null, CancellationToken cancellationToken = default);

        [Get("/api/registry/v1alpha1/apps/{application}/devices/{device}")]
        Task<Device> GetDeviceAsync(string application, string device, [Header("Authorization")] string? authorization = null, CancellationToken cancellationToken = default);
    }
}
