using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonitorDevicesService.models;
using MonitorDevicesService.utils;

namespace MonitorDevicesService.services {
    public class DeviceStatusService {
        private readonly ILogger<DeviceStatusService> _logger; 
        private readonly DateUtils _dateUtils;
        private readonly LogService _logService;

        public DeviceStatusService(ILogger<DeviceStatusService> logger, LogService logService, DateUtils dateUtils) {
            _logger = logger;
            _logService = logService;
            _dateUtils = dateUtils;
        }

        public string GenerateDeviceStatus(Random random) {
            bool isOnline = random.Next(0, 100) > 30;
            return isOnline ? "ONLINE" : "OFFLINE";
        }

        public void CheckDevice(Device device, Random random) {
            try {
                var status = GenerateDeviceStatus(random);
                string logMessage = $"{_dateUtils.GetDateTimeNow()} - {device.Name} - {status}";

                _logger.LogInformation(logMessage);
                _logService.WriteLogToFile(logMessage);
            }

            catch (Exception ex) {
                _logger.LogError(ex, "Erro ao verificar dispositivo {device}", device.Name);
                _logService.WriteLogToFile($"ERRO: {ex.Message}");
            }
        }

    }
}
