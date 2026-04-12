using MonitorDevicesService.data;
using MonitorDevicesService.services;
using MonitorDevicesService.utils;
using MonitorDevicesService.worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<DevicesData>();
builder.Services.AddSingleton<DateUtils>();
builder.Services.AddSingleton<DeviceStatusService>();
builder.Services.AddSingleton<LogService>(); 

var host = builder.Build();
host.Run();
