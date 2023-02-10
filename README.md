# DrogueCloud.Client
A .NET client for the DrogueCloud API ([see specification](https://book.drogue.io/drogue-cloud/dev/api/index.html)).
It uses HttpClientFactory and Refit.

## Example

```c#
var services = new ServiceCollection();
services.AddDrogueCloud(options => {
    options.Endpoint = "https://api.sandbox.drogue.cloud";
    options.Username = "some-user";
    options.Password = "some-password";
});

var provider = services.BuildServiceProvider();
var drogue = provider.GetRequiredService<IDrogueClientApi>();

var app = await drogue.GetAppAsync("some-app");
```
