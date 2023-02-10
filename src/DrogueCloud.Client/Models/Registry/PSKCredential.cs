namespace DrogueCloud.Client.Models.Registry;

/// <summary>
/// A pre shared key used for TLS-PSK encryption.
/// </summary>
public class PSKCredential : ICredential
{
    public byte[] PSK { get; set; } = default!;
}
