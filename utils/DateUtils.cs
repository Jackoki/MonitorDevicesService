namespace MonitorDevicesService.utils {
    public class DateUtils {
        public string GetDateTimeNow() {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
