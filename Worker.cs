using MonitorDevicesService.data;
using MonitorDevicesService.models;

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
            var random = new Random();

            _logger.LogInformation("Worker initiated at: {time}", GetDateTimeNow());

            while (!stoppingToken.IsCancellationRequested) {
                foreach (var device in devices) {
                    CheckDevice(device, random);
                }

                await Task.Delay(10000, stoppingToken);
            }
        }
        private string GenerateDeviceStatus(Random random) {
            bool isOnline = random.Next(0, 100) > 30;
            return isOnline ? "Online" : "Offline";
        }

        private void CheckDevice(Device device, Random random) {
            try {
                var status = GenerateDeviceStatus(random);
                _logger.LogInformation("{time} - {device} - {status}", GetDateTimeNow(), device.Name, status);
            }

            catch (Exception ex) {
                _logger.LogError(ex, "Erro ao verificar dispositivo {device}", device.Name);
            }
        }

        private string GetDateTimeNow() {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
