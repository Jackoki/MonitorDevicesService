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
