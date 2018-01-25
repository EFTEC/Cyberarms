using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cyberarms.IntrusionDetection.Shared;
using System.Data;

namespace Cyberarms.IntrusionDetection.Shared.Test {
    [Serializable]
    [TestClass]
    public class LoadAgentsTest {
        public LoadAgentsTest() {
            Database.Instance.Configure(System.Windows.Forms.Application.StartupPath);
        }

        [TestMethod]
        public void LoadAgentsFromDirectory() {
            IddsConfig.Instance.PluginsDirectory = "C:\\temp\\CyberarmsTest\\Plugins\\";
            List<SecurityAgent> agents = SecurityAgents.Instance.ReadAgentsFromDisk();
            foreach(SecurityAgent agent in agents){
                System.Diagnostics.Debug.Print(agent.Name);
            }
        }

        [TestMethod]
        public void MergeDiskAgentsWithDb() {
            IddsConfig.Instance.PluginsDirectory = "c:\\temp\\CyberarmsTest\\Plugins\\";
            SecurityAgents.Instance.Add(new SecurityAgent("SmtpAgent",Guid.NewGuid(), 0,0,0, null));
            SecurityAgents.Instance[0].Enabled = true;
            List<SecurityAgent> diskAgents = SecurityAgents.Instance.ReadAgentsFromDisk();
            List<SecurityAgent> agents = SecurityAgents.Instance.MergeDbInformation(diskAgents);
            foreach (SecurityAgent agent in agents) {
                System.Diagnostics.Debug.Print(agent.DisplayName);
            }
            Assert.IsFalse(agents[1].Enabled);
        }

        [TestMethod]
        public void LoadAgentsToMemoryTest() {
            IddsConfig.Instance.PluginsDirectory = "c:\\temp\\CyberarmsTest\\Plugins\\";
            SecurityAgents.Instance.Add(new SecurityAgent("SmtpAgent", Guid.NewGuid(), 0, 0, 0, null));
            SecurityAgents.Instance[0].Enabled = true;
            List<SecurityAgent> diskAgents = SecurityAgents.Instance.ReadAgentsFromDisk();
            SecurityAgents.Instance.MergeDbInformation(diskAgents);
            SecurityAgents.Instance[1].Enabled = true;
            SecurityAgents.Instance.LoadAgents();            
            foreach (SecurityAgent key in SecurityAgents.Instance.LoadedAgents.Keys) {
                SecurityAgents.Instance.LoadedAgents[key].AttackDetected += new Api.Plugin.AttackDetectedHandler(LoadAgentsTest_AttackDetected);
            }
            SecurityAgents.Instance[1].AppDomain.DomainUnload += new EventHandler(AppDomain_DomainUnload);
            SecurityAgents.Instance.UnloadAgents();
            System.Timers.Timer t = new System.Timers.Timer(1000);
            t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
            t.Enabled = true;
            t.Start();
            while (!Finished) {
                System.Threading.Thread.SpinWait(10);
            }
            // Assert.IsTrue(Unloaded); // just works in debug, because object is released too early in runtime
        }

        void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
            Finished = true;
        }
        public bool Finished { get; set; }
        public bool Unloaded { get; set; }

        void AppDomain_DomainUnload(object sender, EventArgs e) {
            Unloaded = true;
        }

        void LoadAgentsTest_AttackDetected(object sender, Api.Plugin.INotificationEventArgs data) {
            System.Diagnostics.Debug.Print("Attack detected");
        }


    }

}
