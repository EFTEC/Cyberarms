using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyberarms.IntrusionDetection.Api;
using Cyberarms.IntrusionDetection.Api.Plugin;

namespace Cyberarms.IntrusionDetection {
    internal class Agent {
        internal string AssemblyName { get; set; }
        internal bool Running { get; set; }
        internal Exception LastException { get; set; }
        internal IAgentPlugin Assembly { get; set; }
        internal string Name { get; set; }

        internal Agent(string assemblyName) {
            try {
                this.AssemblyName = assemblyName;
            } catch (Exception ex) {
                this.LastException = ex;
            }
        }

        internal Agent() {
        }
    }
}
