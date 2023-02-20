using DrogueCloud.Client.Models.Admin;
using Refit;

namespace DrogueCloud.Client
{
    public partial interface IDrogueCloudManagementApi
    {
        [Get("/api/admin/v1alpha1/apps/{application}/transfer-ownership")]
        Task<TransferOwnership> GetTransferOwnershipAsync(string application, [Header("Authorization")] string? authorization = null, CancellationToken cancellationToken = default);

        [Get("/api/admin/v1alpha1/apps/{application}/members")]
        Task<ApplicationMembers> GetMembersAsync(string application, [Header("Authorization")] string? authorization = null, CancellationToken cancellationToken = default);
    }
}
