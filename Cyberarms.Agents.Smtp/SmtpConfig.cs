using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyberarms.IntrusionDetection.Api.Plugin;

namespace Cyberarms.Agents.MailServer {
    public class SmtpConfig : PluginConfiguration {
        private int _smtpPort = 0;
        [System.ComponentModel.DefaultValue((int)25)]
        public int SmtpPort {
            get {
                return _smtpPort == 0 ? 25 : _smtpPort;
            }
            set {
                _smtpPort = value == 0 ? 25 : value;
            }
        }
    }
}
