namespace DrogueCloud.Client.Models.Registry;

/// <summary>
/// Username and password credentials.
/// </summary>
public class UserCredential : ICredential
{
    /// <summary>
    /// The username and password combination.
    /// </summary>
    public UserCredentialUser User { get; set; } = default!;
}
