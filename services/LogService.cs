namespace MonitorDevicesService.services {
    public class LogService {
        public void WriteLogToFile(string message) {

            string basePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));

            string directory = Path.Combine(basePath, "logs");
            Directory.CreateDirectory(directory);

            string path = Path.Combine(directory, "logs.txt");

            using (StreamWriter writer = new StreamWriter(path, true)) {
                writer.WriteLine(message);
            }
        }


    }
}
