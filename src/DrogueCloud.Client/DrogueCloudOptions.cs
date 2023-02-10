namespace DrogueCloud.Client
{
    public class DrogueCloudOptions
    {
        public string Endpoint { get; set; } = "https://api.sandbox.drogue.cloud";
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
