namespace DrogueCloud.Client.Models.Registry;

/// <summary>
/// The public key of the device X509 certificate.
/// </summary>
public class CertCredential : ICredential
{
    public string Cert { get; set; } = default!;
}
