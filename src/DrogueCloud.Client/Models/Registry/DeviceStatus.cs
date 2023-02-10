using System.Text.Json;

namespace DrogueCloud.Client.Models.Registry;

/// <summary>
/// A JSON object containing arbritrary status information attached to a device.
/// </summary>
public class DeviceStatus : Dictionary<string, JsonElement>
{
}
