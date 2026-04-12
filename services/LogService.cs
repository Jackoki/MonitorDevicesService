using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorDevicesService.services {
    public class LogService {
        public void WriteLogToFile(string message) {
            string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            Directory.CreateDirectory(directory);

            string path = Path.Combine(directory, "logs.txt");

            using (StreamWriter writer = new StreamWriter(path, true)) {
                writer.WriteLine(message);
            }
        }


    }
}
