using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyberarms.IntrusionDetection.Api.Plugin;

namespace Cyberarms.Agents.TerminalServer {
    public class TslSslConfig : PluginConfiguration {
        private int _rdpPort = 0;
        [System.ComponentModel.DefaultValue((int)3389)]
        public int RdpPort { 
            get {
                return _rdpPort == 0 ? 3389 : _rdpPort;
            }
            set {
                _rdpPort = value == 0 ? 3389 : value;
            }
        }
    }
}
