using MonitorDevicesService.data;
using MonitorDevicesService.models;
using MonitorDevicesService.services;
using MonitorDevicesService.utils;

namespace MonitorDevicesService.worker {
    public class Worker : BackgroundService {
        private readonly ILogger<Worker> _logger;
        private readonly DevicesData _devices;
        private readonly DeviceStatusService _statusService;
        private readonly DateUtils _dateUtils;

        public Worker(ILogger<Worker> logger, DevicesData devices, DeviceStatusService statusService, DateUtils dateUtils) {
            _logger = logger;
            _devices = devices;
            _statusService = statusService;
            _dateUtils = dateUtils;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            var random = new Random();

            _logger.LogInformation("Worker initiated at: {time}", _dateUtils.GetDateTimeNow());

            while (!stoppingToken.IsCancellationRequested) {
                var devices = _devices.GetDevices();
                foreach (var device in devices) {
                    _statusService.CheckDevice(device, random);
                }

                await Task.Delay(10000, stoppingToken);
            }
        }

        
    }
}
