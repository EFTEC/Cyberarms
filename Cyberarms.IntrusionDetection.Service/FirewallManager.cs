using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NATUPNPLib;
using NETCONLib;
using NetFwTypeLib;


namespace Cyberarms.IntrusionDetection {
    internal class FirewallManager {
        private static FirewallManager _instance;
        private INetFwMgr firewallManager; 
        internal static FirewallManager Instance {
            get {
                if (_instance == null) {
                    _instance = new FirewallManager();
                }
                return _instance;

            }
        }

        private FirewallManager() {
            firewallManager = (INetFwMgr)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwMgr"));
        }

        internal void AddPort(string strName,
                                   int Port,
                                   NetFwTypeLib.NET_FW_SCOPE_ Scope,
                                   NetFwTypeLib.NET_FW_IP_PROTOCOL_ Protocol, 
                                   string remoteAddresses) {
            INetFwOpenPort fireWallPort =
                          (INetFwOpenPort)Activator.CreateInstance(
                               Type.GetTypeFromProgID("HNetCfg.FWOpenPort"));
            fireWallPort.RemoteAddresses = remoteAddresses;
            fireWallPort.Enabled = true;
            fireWallPort.Name = strName;
            fireWallPort.Port = Port;
            fireWallPort.Protocol = Protocol;

            firewallManager.LocalPolicy.CurrentProfile
                                       .GloballyOpenPorts.Add(fireWallPort);
        }

        

        internal void RemovePort(int Port,
                                      NetFwTypeLib.NET_FW_IP_PROTOCOL_ Protocol) {
            firewallManager.LocalPolicy.CurrentProfile
               .GloballyOpenPorts.Remove(Port, Protocol);
        }

        internal void AddAuthorizedApplication(string strName,
                                                string processImageFileName,
                                                NetFwTypeLib.NET_FW_SCOPE_ Scope) {
            INetFwAuthorizedApplication authorizedApplication
                  = (INetFwAuthorizedApplication)Activator
                          .CreateInstance(Type.GetTypeFromProgID(
                                    "HNetCfg.FwAuthorizedApplication"));
            authorizedApplication.Name = strName;
            authorizedApplication.Scope = Scope;
            authorizedApplication.Enabled = true;
            authorizedApplication.ProcessImageFileName = processImageFileName;
            firewallManager.LocalPolicy.CurrentProfile
                           .AuthorizedApplications.Add(authorizedApplication);
        }

        internal void RemoveAuthorizedApplication(string processFileName) {
            firewallManager.LocalPolicy.CurrentProfile
                           .AuthorizedApplications.Remove(processFileName);
        }

        internal INetFwOpenPort ReadPort(string name) {
            INetFwOpenPorts ports = firewallManager.LocalPolicy.CurrentProfile.GloballyOpenPorts;
            foreach (INetFwOpenPort port in ports) {
                System.Diagnostics.Debug.Print(port.Name);
                if (port.Name == name) return port;
            }
            return null;

        }

    }
}
