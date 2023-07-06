using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanganKananMandor
{
    public  class ServiceDetector
    {
        public string Execute()
        {
            var runningProcesses = Process.GetProcesses().ToList();
            var monitoredProcess = new List<RunningServiceModel>
            {
                new RunningServiceModel("Jkn2.SvcApp", "Custom Hit"),
                new RunningServiceModel("HiDokNotifManager", "Hidok Notif"),
                new RunningServiceModel("sqlservr", "Database"),
            };

            foreach (var item in monitoredProcess)
            {
                var theService = runningProcesses.FirstOrDefault(x => x.ProcessName == item.ServiceName);
                item.State = theService is null ? "Stop" : "Running";
                item.LastCheck = DateTime.Now.ToString("HH:mm:ss");
            }

            var result = monitoredProcess.Select(x =>
            {
                return $"{x.LastCheck} {x.ServiceDescription.PadRight(20)} : {x.State}";
            });
            var response = string.Join("\n", result);
            return $"{response}";
        }
    }

    public class RunningServiceModel
    {
        public RunningServiceModel(string name, string desc)
        {
            ServiceName = name;
            ServiceDescription = desc;
        }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public string State { get; set; }
        public string LastCheck { get; set; }
    }
}
