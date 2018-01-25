using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace Cyberarms.IntrusionDetection {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args) {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new Service() 
			};
            System.Windows.Forms.Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            try {
                ServiceBase.Run(ServicesToRun);
            } catch (Exception ex) {
                System.Diagnostics.EventLog.WriteEntry("Cyberarms Intrusion Detection Service", ex.Message);
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e) {
            System.Diagnostics.EventLog.WriteEntry("Cyberarms Intrusion Detection Service Base", e.Exception.Message, System.Diagnostics.EventLogEntryType.Error);
        }
    }
}
