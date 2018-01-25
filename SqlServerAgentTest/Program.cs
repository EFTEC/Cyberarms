using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyberarms.IntrusionDetection.Api.Plugin;
using Cyberarms.Agents.SqlServer;

namespace SqlServerAgentTest {
    class Program {
        static void Main(string[] args) {
            SqlFailedLoginWatcher watcher = new SqlFailedLoginWatcher();
            watcher.AttackDetected += new AttackDetectedHandler(watcher_AttackDetected);
            watcher.Start();
            Console.ReadKey();
            watcher.Stop();
        }

        static void watcher_AttackDetected(object sender, INotificationEventArgs data) {
            SqlFailedLoginWatcher watcher = (SqlFailedLoginWatcher)sender;
            Console.WriteLine("{0}: {1}", data.EventMessage, data.IpAddress);
        }
    }
}
