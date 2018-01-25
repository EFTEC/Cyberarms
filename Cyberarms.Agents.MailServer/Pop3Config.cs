using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyberarms.IntrusionDetection.Api.Plugin;

namespace Cyberarms.Agents.MailServer {
    public class Pop3Config : PluginConfiguration {

        private int _pop3Port = 0;
        [System.ComponentModel.DefaultValue((int)110)]
        public int Pop3Port {
            get {
                return _pop3Port == 0 ? 110 : _pop3Port;
            }
            set {
                _pop3Port = value == 0 ? 110 : value;
            }
        }


    }
}
