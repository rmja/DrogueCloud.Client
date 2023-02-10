namespace DrogueCloud.Client.Models.Registry;

/// <summary>
/// Timestamps constraining the validity of a PSK.
/// </summary>
public class Validity
{
    /// <summary>
    /// Before this date the key will be invalid.
    /// </summary>
    public DateTimeOffset? NotBefore { get; set; }

    /// <summary>
    /// After this date the key will be invalid.
    /// </summary>
    public DateTimeOffset? NotAfter { get; set; }
}
