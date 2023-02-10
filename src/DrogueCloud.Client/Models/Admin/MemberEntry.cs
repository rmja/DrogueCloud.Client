namespace DrogueCloud.Client.Models.Admin;

public class MemberEntry
{
    /// <summary>
    /// The member role, any of: reader, writer, or admin.
    /// </summary>
    public string Role { get; set; } = default!;
}
