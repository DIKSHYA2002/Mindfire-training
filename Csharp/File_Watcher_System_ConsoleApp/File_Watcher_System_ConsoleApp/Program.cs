using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;
namespace MyNamespace
{
    
    class MyClassCS
    {
        public static string GetFilePath()
        {
            string filepath = ConfigurationManager.AppSettings.Get("LogFilePath") + DateTime.Now.ToShortDateString() + ".txt";
            return filepath;
        }
        static void Main()
        {
           var watcher = new FileSystemWatcher(ConfigurationManager.AppSettings.Get("DirectoryPath"));
            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;
            watcher.Error += OnError;

            watcher.Filter = "*.*";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
          
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            DateTime currentDateTime = DateTime.Now;
            using (StreamWriter sw = File.AppendText(GetFilePath()))
            {
                sw.WriteLine(currentDateTime.ToShortDateString());
                sw.WriteLine(currentDateTime.ToString("HH:mm") + $"---> Changed: {e.FullPath}");
            }
            Console.WriteLine($"Changed: {e.FullPath}");
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            string value = $"Created: {e.FullPath}";
            Console.WriteLine(value);
            DateTime currentDateTime = DateTime.Now;
            using (StreamWriter sw = File.AppendText(GetFilePath()))
            {
                sw.WriteLine(currentDateTime.ToShortDateString());
                sw.WriteLine(currentDateTime.ToString("HH:mm") + $"---> Created: {e.FullPath}");
            }

        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {

            Console.WriteLine($"Deleted: {e.FullPath}");
            var currentTime = DateTime.Now;
            DateTime currentDateTime = DateTime.Now;
            using (StreamWriter sw = File.AppendText(GetFilePath()))
            {
                sw.WriteLine(currentDateTime.ToShortDateString());
                sw.WriteLine(currentDateTime.ToString("HH:mm") + $"---> Deleted: {e.FullPath}");
            }
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"---> Renamed:Old: {e.OldFullPath}, New: {e.FullPath}");
            DateTime currentDateTime = DateTime.Now;
            using (StreamWriter sw = File.AppendText(GetFilePath()))
            {
                sw.WriteLine(currentDateTime.ToShortDateString());
                sw.WriteLine(currentDateTime.ToString("HH:mm") + $"--->Renamed:Old: {e.OldFullPath}, New: {e.FullPath}");
            }
        }

        private static void OnError(object sender, ErrorEventArgs e) =>
            PrintException(e.GetException());
        private static void PrintException(Exception ex)
        {
            if (ex != null)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine("Stacktrace:");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
                PrintException(ex.InnerException);
            }
        }
    }
}