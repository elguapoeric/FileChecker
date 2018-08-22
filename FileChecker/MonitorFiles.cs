using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FileChecker
{
    class MonitorFiles
    {
        string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\FilesChanged.txt";
        public MonitorFiles(string monitorpath)
        {
            
            
            //Using the FileSystemWatcher to monitor file changes in a specific file
            FileSystemWatcher monitor = new FileSystemWatcher(monitorpath);
            monitor.IncludeSubdirectories = false; //dont want to monitor subdirectories
            monitor.EnableRaisingEvents = true;
           
            


            //Add event handler
            monitor.Changed += monitor_Changed;
            monitor.Created += monitor_Created;
            monitor.Deleted += monitor_Deleted;
            monitor.Renamed += monitor_Renamed;



            Console.Read();
        }

        private void monitor_Renamed(object sender, RenamedEventArgs e)
        {
            if (!File.Exists(path))
            {
                string welcome = $"LIST OF FILES DELETED OR MODIFIED" + Environment.NewLine;
                File.WriteAllText(path, welcome);
            }
            
            string message = $"{e.OldName} has been renamed to {e.Name} at {DateTime.Now.ToLocalTime()}" + Environment.NewLine;
            File.AppendAllText(path, message);
            Console.WriteLine(message);

        }

        private void monitor_Deleted(object sender, FileSystemEventArgs e)
        {
            if (!File.Exists(path))
            {
                string welcome = $"LIST OF FILES DELETED OR MODIFIED" + Environment.NewLine;
                File.WriteAllText(path, welcome);
            }

            string message = $"{e.Name} was deleted at {DateTime.Now.ToLocalTime()}" + Environment.NewLine;
            File.AppendAllText(path, message);
            Console.WriteLine(message);

        }

        private void monitor_Created(object sender, FileSystemEventArgs e)
        {
            if (!File.Exists(path))
            {
                string welcome = $"LIST OF FILES DELETED OR MODIFIED" + Environment.NewLine;
                File.WriteAllText(path, welcome);
            }

            string message = $"{e.Name} was created at {DateTime.Now.ToLocalTime()}" + Environment.NewLine; ;
            File.AppendAllText(path, message);
            Console.WriteLine(message);
            
        }

        private void monitor_Changed(object sender, FileSystemEventArgs e)
        {
            if (!File.Exists(path))
            {
                string welcome = $"LIST OF FILES DELETED OR MODIFIED" + Environment.NewLine;
                File.WriteAllText(path, welcome);
            }

            string message = $"{e.Name} was modified at {DateTime.Now.ToLocalTime()}" + Environment.NewLine; ;
            File.AppendAllText(path, message);
            Console.WriteLine(message);

        }
    }
}
