using MonitorDevicesService.data;
using MonitorDevicesService.models;
using MonitorDevicesService.services;
using MonitorDevicesService.utils;

namespace MonitorDevicesService.worker {
    public class Worker : BackgroundService {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;

        private readonly DevicesData _devices;
        private readonly DeviceStatusService _statusService;
        private readonly DateUtils _dateUtils;

        public Worker(ILogger<Worker> logger, DevicesData devices, DeviceStatusService statusService, DateUtils dateUtils, IConfiguration configuration) {
            _logger = logger;
            _devices = devices;
            _statusService = statusService;
            _dateUtils = dateUtils;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            var random = new Random();

            _logger.LogInformation("Worker initiated at: {time}", _dateUtils.GetDateTimeNow());

            while (!stoppingToken.IsCancellationRequested) {
                var devices = _devices.GetDevices();
                foreach (var device in devices) {
                    _statusService.CheckDevice(device, random);
                }

                int interval = _configuration.GetValue<int>("IntervalSeconds");
                await Task.Delay(interval * 1000, stoppingToken);
            }
        }

        
    }
}
