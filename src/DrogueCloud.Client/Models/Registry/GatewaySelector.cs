namespace DrogueCloud.Client.Models.Registry;

public class GatewaySelector
{
    /// <summary>
    /// Each: The device ID of the device to use as a gateway.
    /// </summary>
    public List<string>? MatchNames { get; set; }
}
