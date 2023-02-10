using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DrogueCloud.Client.Models.Registry;

/// <summary>
/// A JSON object containing arbritrary data attached to an application.
/// </summary>
[JsonConverter(typeof(ObjectMapJsonConverter))]
[DebuggerTypeProxy(typeof(ObjectMapDebugView<ApplicationSpec>))]
public class ApplicationSpec : Dictionary<string, JsonElement>
{
}
