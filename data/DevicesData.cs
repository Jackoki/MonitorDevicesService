using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonitorDevicesService.models;

namespace MonitorDevicesService.data {
    public class DevicesData {
        private readonly IConfiguration _configuration;

        public DevicesData(IConfiguration configuration) {
            _configuration = configuration;
        }

        public List<Device> GetDevices() {
            return _configuration.GetSection("Devices").Get<List<Device>>();
        }
    }
}
