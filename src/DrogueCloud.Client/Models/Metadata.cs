namespace DrogueCloud.Client.Models;

public abstract class Metadata
{
    public DateTimeOffset CreationTimestamp { get; set; }

    public string Name { get; set; } = default!;

    /// <summary>
    /// An ID of the current version of this resource.
    /// </summary>
    public string? ResourceVersion { get; set; }

    /// <summary>
    /// A unique ID of the resource.
    ///
    /// Deleting and re-creating a resource with the same name will still result in a different unique ID.
    /// </summary>
    public string Uid { get; set; } = default!;
    public int Generation { get; set; }

    /// <summary>
    /// A marker for soft-deletion.
    ///
    /// When the resource is deleted, it will first be marked as deleted, by setting the deletion timestamp.
    /// Once all finalizers are removed, the resource will actually be deleted.
    /// </summary>
    public DateTimeOffset? DeletionTimestamp { get; set; }

    /// <summary>
    /// A list of finalizers.
    ///
    /// As long as finalizers are present, the resource will not be deleted even if the deletionTimestamp is set.
    /// </summary>
    public List<string>? Finalizers { get; set; }

    /// <summary>
    /// Arbitrary additional information.
    /// </summary>
    public Dictionary<string, string>? Annotations { get; set; }

    /// <summary>
    /// Additional labels which can used for searching.
    ///
    /// Labels are limited in size and format, similar to the Kubernetes labels.
    /// </summary>
    public Dictionary<string, string>? Labels { get; set; }
}
