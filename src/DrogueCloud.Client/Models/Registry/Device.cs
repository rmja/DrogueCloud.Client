namespace DrogueCloud.Client.Models.Registry;

public class Device
{
    public ScopedMetadata? Metadata { get; set; }
    public DeviceSpec? Spec { get; set; }
    public DeviceStatus? Status { get; set; }
}
