using MonitorDevicesService.data;

namespace MonitorDevicesService {
    public class Worker : BackgroundService {
        private readonly ILogger<Worker> _logger;
        private readonly DevicesData _devices;

        public Worker(ILogger<Worker> logger, DevicesData devices) {
            _logger = logger;
            _devices = devices;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            var devices = _devices.GetDevices();

            _logger.LogInformation("Worker initiated at: {time}", DateTimeOffset.Now);

            while (!stoppingToken.IsCancellationRequested) {
                if (_logger.IsEnabled(LogLevel.Information)) {
                    foreach (var device in devices) {
                        _logger.LogInformation("Checking device: {name} - {ip}", device.Name, device.Ip);
                    }
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }
    }
}
