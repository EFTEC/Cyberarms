using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyberarms.IntrusionDetection.Api.Plugin;

namespace Cyberarms.Agents.Bind9 {
    public class Bind9DDoSConfig : AgentConfigurationBase {
        [System.ComponentModel.DefaultValue(false)]
        public bool RestartBindOnBlock { get; set; }        
    }
}
