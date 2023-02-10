namespace DrogueCloud.Client.Models.Admin;

public class ApplicationMembers
{
    /// <summary>
    /// The version of the resource.
    /// When setting a new member list, this value is optional.
    /// But if present, the application will only be updated if the resource version matches.
    /// Otherwise it will return a "Conflict".
    /// </summary>
    public string? ResourceVersion { get; set; }
    public Dictionary<string, MemberEntry> Members { get; set; } = new();
}
