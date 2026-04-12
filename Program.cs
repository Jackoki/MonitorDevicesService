using MonitorDevicesService;
using MonitorDevicesService.data;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<DevicesData>();

var host = builder.Build();
host.Run();
