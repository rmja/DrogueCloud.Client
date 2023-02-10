namespace DrogueCloud.Client.Models;

public class ScopedMetadata : Metadata
{
    /// <summary>
    /// The name of the application the resource is scoped to.
    /// </summary>
    public string Application { get; set; } = default!;
}
