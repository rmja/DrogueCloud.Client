namespace DrogueCloud.Client
{
    public class DrogueCloudDeviceApiOptions : IApiCredentials
    {
        public string Endpoint { get; set; } = "https://http.sandbox.drogue.cloud";
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
