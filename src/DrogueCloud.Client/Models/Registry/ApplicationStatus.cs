using System.Text.Json;

namespace DrogueCloud.Client.Models.Registry;

/// <summary>
/// A JSON object containing arbritrary status information attached to an application.
/// </summary>
public class ApplicationStatus : Dictionary<string, JsonElement>
{
}
