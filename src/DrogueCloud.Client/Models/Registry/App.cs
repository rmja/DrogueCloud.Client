namespace DrogueCloud.Client.Models.Registry;

public class App
{
    public ScopedMetadata Metadata { get; set; } = default!;
    public ApplicationSpec? Spec { get; set; }
    public ApplicationStatus? Status { get; set; }
}
