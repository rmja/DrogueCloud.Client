using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DrogueCloud.Client.Models.Registry;

/// <summary>
/// A JSON object containing arbritrary data attached to a device.
/// </summary>
[JsonConverter(typeof(ObjectMapJsonConverter))]
[DebuggerTypeProxy(typeof(ObjectMapDebugView<DeviceSpec>))]
public class DeviceSpec : Dictionary<string, JsonElement>
{
    public DeviceSpecAuthentication? Authentication { get; set; }
    public GatewaySelector? GatewaySelector { get; set; }
    public Alias? Alias { get; set; }
}
