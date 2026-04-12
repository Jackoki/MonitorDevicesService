using MonitorDevicesService.models;
using MonitorDevicesService.utils;

namespace MonitorDevicesService.services {
    public class DeviceStatusService {
        private readonly ILogger<DeviceStatusService> _logger;
        private readonly IConfiguration _configuration;
        private readonly DateUtils _dateUtils;
        private readonly LogService _logService;
        private readonly int _maxRetries;

        public DeviceStatusService(ILogger<DeviceStatusService> logger, IConfiguration configuration, LogService logService, DateUtils dateUtils) {
            _logger = logger;
            _configuration = configuration;
            _logService = logService;
            _dateUtils = dateUtils;

            _maxRetries = _configuration.GetValue<int>("MaxRetries");
        }

        public string GenerateDeviceStatus(Random random) {
            bool isOnline = random.Next(0, 100) > 30;
            return isOnline ? "ONLINE" : "OFFLINE";
        }

        public void CheckDevice(Device device, Random random) {
            int attempt = 0;

            while (attempt < _maxRetries) {
                try {
                    var status = GenerateDeviceStatus(random);
                    string logMessage = $"{_dateUtils.GetDateTimeNow()} - {device.Name} - {status}";

                    _logger.LogInformation(logMessage);
                    _logService.WriteLogToFile(logMessage);

                    return;
                }

                catch (Exception ex) {
                    attempt++;

                    _logger.LogError(ex, "Erro ao verificar dispositivo {device}. Tentativa {attempt}", device.Name, attempt);
                    _logService.WriteLogToFile($"ERRO: {device.Name} - tentativa {attempt} - {ex.Message}");

                    if (attempt >= _maxRetries) {
                        _logService.WriteLogToFile($"FALHA DEFINITIVA: {device.Name} - {ex.Message}");
                        return;
                    }
                }
            }
        }

    }
}
