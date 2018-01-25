using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NATUPNPLib;
using NETCONLib;
using NetFwTypeLib;
using Cyberarms.IntrusionDetection.Shared;


namespace Cyberarms.IntrusionDetection {
    internal class FirewallPolicyManager {
        private INetFwPolicy2 firewallPolicyManager;
        private static FirewallPolicyManager _instance;

        internal static FirewallPolicyManager Instance {
            get {
                if (_instance == null) {
                    _instance = new FirewallPolicyManager();
                }
                return _instance;
            }
        }

        private FirewallPolicyManager() {
            firewallPolicyManager = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

        }

        internal void Block(string ipAddress) {
            try {
                AddRule("BlockAttacker", 0, NetFwTypeLib.NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_ANY,
                    NetFwTypeLib.NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN, NetFwTypeLib.NET_FW_SCOPE_.NET_FW_SCOPE_CUSTOM,
                    NetFwTypeLib.NET_FW_ACTION_.NET_FW_ACTION_BLOCK, ipAddress);
            } catch (Exception ex) {
                System.Diagnostics.EventLog.WriteEntry("Create Firewall Rule",ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        internal bool IsLocked(string ipAddress) {
            try {
                INetFwRule rule = GetRule(GetRuleName("BlockAttacker", 0));
                return rule.RemoteAddresses.Contains(ipAddress);
            } catch (Exception ex) {
                System.Diagnostics.EventLog.WriteEntry("IsLocked encountered an error: ", ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return false;
        }

        internal void RemoveIpAddressFromBlockList(string ipAddress) {
            string ruleName = GetRuleName("BlockAttacker", 0);
            INetFwRule rule = GetRule(ruleName);
            if (!rule.RemoteAddresses.Contains(ipAddress)) {
                throw new ArgumentException(String.Format(
                    "The IP address {0} is not blocked and might has been automatically removed by schedule. Please refresh the list to view current locks.", ipAddress));
            }
            rule.RemoteAddresses = GetCleanedRemoteAddresses(rule.RemoteAddresses, ipAddress);
            if (rule.RemoteAddresses == "*" || String.IsNullOrEmpty(rule.RemoteAddresses.Replace(',',' ').Trim())) {
                rule.Enabled = false;
            }
        }

        private string GetCleanedRemoteAddresses(string addresses, string removeAddress) {
            StringBuilder result = new StringBuilder();
            string[] addressList;
            if (addresses.Contains(',')) {
                addressList = addresses.Split(',');
            } else {
                addressList = new string[1];
                addressList[0] = addresses;
            }
            foreach(string address in addressList) {
                string part1 = String.Empty;
                if (address.Contains('/')) {
                    part1 = address.Split('/')[0];
                } else {
                    part1 = address;
                }
                if (!part1.Trim().Equals(removeAddress.Trim()) && !address.Trim().Equals(removeAddress.Trim())) {
                    result.Append(address + ",");
                }
            }
            return result.ToString();
        }

        private string GetRuleName(string name, int port) {
            return String.Format("{0}_{1}_{2}", Globals.CYBERARMS_WINDOWS_IDS_RULE_NAME, name, port == 0 ? "AllPorts" : port.ToString());
        }

        internal void AddRule(string name, int port, NET_FW_IP_PROTOCOL_ protocol, NetFwTypeLib.NET_FW_RULE_DIRECTION_ direction, 
            NetFwTypeLib.NET_FW_SCOPE_ scope, NetFwTypeLib.NET_FW_ACTION_ action, string remoteAddress) {
            bool ruleExists = false;
            string ipAddress;
            string ruleName = GetRuleName(name, port);
            INetFwRule rule = GetRule(ruleName);
            if (rule != null) {
                ruleExists = true;
            } else {
                try {
                    rule = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule", true));
                } catch (Exception x) {
                    throw x;
                }
            }
            if(IddsConfig.IsValidIpAddress(remoteAddress)) {
                ipAddress = remoteAddress;
            } else {
                throw new ArgumentOutOfRangeException("IP address must be given in IP version 4 or IP version 6 format!");
            }
            // ipAddress = String.Format("{0}/255.255.255.255", ipAddress);

            if (!ruleExists) {
                rule.Action = action;
                rule.Grouping = Globals.CYBERARMS_WINDOWS_IDS_GROUP_NAME;
                rule.Protocol = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                rule.Description = Globals.CYBERARMS_WINDOWS_IDS_GROUP_NAME + " rule";
                rule.Direction = direction;
                rule.Enabled = true;

                if(port>0) rule.LocalPorts = port.ToString();
                rule.Name = ruleName;
                rule.RemoteAddresses = ipAddress;
                //  rule.RemotePorts = "";
                firewallPolicyManager.Rules.Add(rule);
            } else {
                rule.Enabled = true;
                if (rule.RemoteAddresses.Trim().Equals("*")) {
                    rule.RemoteAddresses = ipAddress;
                } else {
                    rule.RemoteAddresses = String.Format("{0},{1}", rule.RemoteAddresses, ipAddress);
                }
            }
        }

        internal void CleanUpRules() {
            foreach (INetFwRule rule in FindRules(Globals.CYBERARMS_WINDOWS_IDS_RULE_NAME)) {
                //rule.RemoteAddresses = "";
                firewallPolicyManager.Rules.Remove(rule.Name);
            }
        }

        internal INetFwRule GetRule(string name) {
            foreach (INetFwRule rule in firewallPolicyManager.Rules) {
                if (rule.Name == name) return rule;
            }
            return null;
        }

        internal List<INetFwRule> FindRules(string name) {
            List<INetFwRule> rules = new List<INetFwRule>();
            foreach (INetFwRule rule in firewallPolicyManager.Rules) {
                if (rule.Name.StartsWith(name)) rules.Add(rule);
            }
            return rules;
        }

    }
}
