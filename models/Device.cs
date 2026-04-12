using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorDevicesService.models {
    public class Device {
        public string Name { get; set; }
        public string Ip { get; set; }

        public Device(string Name, string Ip) {
            this.Name = Name;
            this.Ip = Ip;
        }
    }
}
