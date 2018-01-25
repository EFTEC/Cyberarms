using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyberarms.IntrusionDetection.Api.Plugin;

namespace DemoAgent {
    public class BadAgent : AgentPlugin {
        public BadAgent() {
        }

        protected override void OnStartAgent() {
            base.OnStartAgent();
            while (true) ;
            
        }
    }
}
