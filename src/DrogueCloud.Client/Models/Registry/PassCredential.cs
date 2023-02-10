namespace DrogueCloud.Client.Models.Registry;

/// <summary>
/// Password credential.
/// </summary>
public class PassCredential : ICredential
{
    public Password Pass { get; set; } = default!;
}
