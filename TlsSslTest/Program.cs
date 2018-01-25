using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cyberarms.Agents.TerminalServer;
using Cyberarms.IntrusionDetection.Api.Plugin;

namespace TlsSslTest {
    class Program {
        static void Main(string[] args) {
            TlsSslAgent agent = new TlsSslAgent();
            agent.Trace += new EventHandler(agent_Trace);
            agent.Tracing = false;
            agent.AttackDetected += new Cyberarms.IntrusionDetection.Api.Plugin.AttackDetectedHandler(agent_AttackDetected);
            ((Cyberarms.Agents.TerminalServer.TslSslConfig)agent.Configuration.AgentSettings).RdpPort = 3389;
            agent.Start();
            Console.WriteLine("Press any key to abort...");
            Console.ReadKey();
        }

        static void agent_AttackDetected(object sender, Cyberarms.IntrusionDetection.Api.Plugin.INotificationEventArgs data) {
            Console.WriteLine("AttackDetected from " + data.IpAddress);
        }

        static void agent_Trace(object sender, EventArgs e) {
            IPHeader tls = (IPHeader)sender;
            //Console.WriteLine("{0} {1} {2} {3}", tls.TlsHeader.ContentType, tls.TlsHeader.MajorVersion, tls.TlsHeader.MinorVersion, tls.TlsHeader.Length);
            for (int i = 0; i < int.Parse(tls.TotalLength);i++ ) {
                Console.Write("{0:X}", tls.Data[i]);
            }
            Console.WriteLine();
        }
    }
}
