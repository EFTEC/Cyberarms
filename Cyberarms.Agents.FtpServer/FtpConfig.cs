using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyberarms.IntrusionDetection.Api.Plugin;

namespace Cyberarms.Agents.FtpServer {
    public class FtpConfig : PluginConfiguration {
        private int _ftpPort = 0;
        [System.ComponentModel.DefaultValue((int)21)]
        public int FtpPort { 
            get {
                return _ftpPort == 0 ? 21 : _ftpPort;
            }
            set {
                _ftpPort = value == 0 ? 21 : value;
            }
        }

    }
}
