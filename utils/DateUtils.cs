using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorDevicesService.utils {
    public class DateUtils {
        public string GetDateTimeNow() {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
