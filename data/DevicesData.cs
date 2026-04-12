using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonitorDevicesService.models;

namespace MonitorDevicesService.data {
    public class DevicesData {
        List<Device> devices;

        public DevicesData() {
            devices = new List<Device>();
            devices.Add(new Device("CLP Linha 1", "192.168.0.1"));
            devices.Add(new Device("CLP Linha 2", "192.168.0.2"));
        }

        public List<Device> GetDevices() {
            return devices;
        }
    }
}
