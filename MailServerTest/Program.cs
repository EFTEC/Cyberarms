using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyberarms.Agents.MailServer;

namespace MailServerTest {
    class Program {
        static void Main(string[] args) {
            Pop3Agent agent = new Pop3Agent();
            agent.CurrentClients.Add(1, new Pop3Client());
            agent.CurrentClients.Add(2, new Pop3Client());
            agent.CurrentClients.Add(10, new Pop3Client());
            agent.CurrentClients.Add(1000, new Pop3Client());
            for (int i = agent.CurrentClients.Keys.Max(); i > 0; i--) {
                if (agent.CurrentClients.ContainsKey(i) && i==10) agent.CurrentClients.Remove(i);
            }
            Console.WriteLine(agent.CurrentClients.Count);
            Console.ReadKey();
        }
    }
}
