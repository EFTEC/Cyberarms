using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using System.Reflection;
using Cyberarms.IntrusionDetection.Api.Plugin;

namespace Cyberarms.IntrusionDetection.Shared {
    [Serializable]
    public class SecurityAgents : List<SecurityAgent> {
        private SecurityAgents() {
        }


        private static SecurityAgents _instance;
        public static SecurityAgents Instance {
            get {
                if (_instance == null) {
                    _instance = new SecurityAgents();
                    _instance.InitializeAgents();
                }
                return _instance;
            }
        }

        public void InitializeAgents() {
            this.Clear();
            if (!Database.Instance.IsConfigured) {
                throw new ApplicationException("Database is not configured yet. Please configure database and re-try this operation!");
            }

            IDataReader rdr = Database.Instance.ExecuteReader("select * from securityAgents");
            // load all agents
            while (rdr.Read()) {
                SecurityAgent agent = new SecurityAgent();
                agent.Name = Db.DbValueConverter.ToString(rdr["Name"]);
                agent.AssemblyName = Db.DbValueConverter.ToString(rdr["AssemblyName"]);
                agent.Id = Db.DbValueConverter.ToGuid(rdr["AgentId"]);
                agent.HardLockAttempts = Db.DbValueConverter.ToInt(rdr["HardLockAttempts"]);
                agent.HardLockTimeHours = Db.DbValueConverter.ToInt(rdr["HardLockTimeHours"]);
                agent.LockForever = Db.DbValueConverter.ToBool(rdr["LockForever"]);
                agent.SoftLockAttempts = Db.DbValueConverter.ToInt(rdr["SoftLockAttempts"]);
                agent.SoftLockTimeMinutes = Db.DbValueConverter.ToInt(rdr["SoftLockTimeMinutes"]);
                agent.OverrideConfig = Db.DbValueConverter.ToBool(rdr["OverwriteConfiguration"]);
                agent.DisplayName = Db.DbValueConverter.ToString(rdr["DisplayName"]);
                agent.Enabled = Db.DbValueConverter.ToBool(rdr["Enabled"]);
                agent.Serial = Db.DbValueConverter.ToInt(rdr["Serial"]);
                //agent.LoadCustomConfig();
                this.Add(agent);
            }
            rdr.Close();
        }

        public List<SecurityAgent> ReadAgentsFromDisk() {
            if (String.IsNullOrEmpty(IddsConfig.Instance.PluginsDirectory)) throw new ApplicationException("Application is not initialized.");
            List<SecurityAgent> result = new List<SecurityAgent>();
            AppDomainSetup setup = AppDomain.CurrentDomain.SetupInformation;
            System.Security.Policy.Evidence adevidence = AppDomain.CurrentDomain.Evidence;
            CurrentDomain = AppDomain.CreateDomain("Cyberarms.Agents.Enumerator", adevidence, setup);
            
            foreach (string fileName in Directory.EnumerateFiles(IddsConfig.Instance.PluginsDirectory, "*.dll")) {
                if (!fileName.Contains(".Api.dll")) {
                    Type tProxy = typeof(AgentLoaderProxy);
                    AgentLoaderProxy proxy = (AgentLoaderProxy)CurrentDomain.CreateInstanceAndUnwrap(
                        tProxy.Assembly.FullName,
                        tProxy.FullName);
                    List<SecurityAgent> agents = proxy.GetSecurityAgents(fileName);
                    result.AddRange(agents);
                    
                }
            }
            return result;
        }

        public AppDomain CurrentDomain { get; set; }

        public SecurityAgent FindByDisplayName(string displayName) {
            foreach (SecurityAgent agent in this) {
                if (agent.DisplayName == displayName) {
                    return agent;
                }
            }
            return null;
        }

        public SecurityAgent FindByName(string name) {
            foreach(SecurityAgent agent in this) {
                if (agent.Name == name) {
                    return agent;
                }
            }
            return null;
        }

        public string GetDisplayName(string agentId) {
            if(Guid.Empty.ToString().Equals(agentId)) {
                return "None";
            }
            foreach (SecurityAgent agent in this) {
                if (agent.Id.ToString().Equals(agentId)) {
                    return agent.DisplayName;
                }
            }
            return String.Format("Agent {0} is not registered.", agentId);
        }

        public void RegisterSecurityAgents() {
            MergeDbInformation(ReadAgentsFromDisk());
        }

        public Dictionary<SecurityAgent, AgentProxy> LoadedAgents { get; set; }

        public void UnloadAgents() {
            if (LoadedAgents == null) return;
            AppDomainManager adm = new AppDomainManager();
            
            foreach(SecurityAgent agent in LoadedAgents.Keys) {
                AppDomain.Unload(agent.AppDomain);
            }
            LoadedAgents.Clear();
        }

        public void UnloadAgent(SecurityAgent agent) {
            AppDomain.Unload(agent.AppDomain);
            if (LoadedAgents.ContainsKey(agent)) {
                LoadedAgents[agent] = null;
                LoadedAgents.Remove(agent);
            } else {
                throw new ApplicationException("Agent " + agent.DisplayName + " is not loaded.");
            }
        }

        void AppDomain_DomainUnload(object sender, EventArgs e) {
            System.Diagnostics.Debug.Print("Agent AppDomain unloaded");
        }

        public void LoadAgents() {
            if (LoadedAgents == null) LoadedAgents = new Dictionary<SecurityAgent, AgentProxy>();
            if (LoadedAgents.Count > 0) UnloadAgents();
            foreach (SecurityAgent agent in this) {
                if (agent.Enabled) {
                    try {
                        AppDomainSetup setup = AppDomain.CurrentDomain.SetupInformation;
                        System.Security.Policy.Evidence adevidence = AppDomain.CurrentDomain.Evidence;
                        AppDomain domain = AppDomain.CreateDomain("Cyberarms.Agents." + agent.Id, adevidence, setup);
                        AgentProxy proxy = new AgentProxy(agent.AssemblyFilename, agent.Name);
                        proxy.Configuration.AgentName = agent.Name;
                        proxy.Configuration.AssemblyName = agent.AssemblyName;
                        proxy.Configuration.Enabled = agent.Enabled;
                        proxy.Configuration.HardLockAttempts = agent.HardLockAttempts;
                        proxy.Configuration.HardLockDurationHrs = agent.HardLockTimeHours;
                        proxy.Configuration.NeverUnlock = agent.LockForever;
                        proxy.Configuration.OverwriteConfiguration = agent.OverrideConfig;
                        proxy.Configuration.SoftLockAttempts = agent.SoftLockAttempts;
                        proxy.Configuration.SoftLockDurationMins = agent.SoftLockTimeMinutes;
                        PluginConfiguration pc = proxy.Configuration.AgentSettings;
                        if(pc!=null) {
                            foreach(PropertyInfo pi in pc.GetType().GetProperties()) {
                                if (agent.CustomConfiguration.ContainsKey(pi.Name)) {
                                    if (pi.PropertyType == typeof(int)) {
                                        int result;
                                        int.TryParse(agent.CustomConfiguration[pi.Name], out result);
                                        pi.SetValue(pc, result, null);
                                    }
                                }
                            }
                        }
                        agent.AppDomain = domain;
                        agent.Reload();
                        LoadedAgents.Add(agent, proxy);
                    } catch (Exception ex) {
                        throw ex;
                    }
                }
            }
        }

        public void StartAgents() {
            foreach (AgentProxy agent in LoadedAgents.Values) {
                agent.Start();
            }
        }

        public void StopAgents() {
            foreach (AgentProxy agent in LoadedAgents.Values) {
                agent.Stop();
            }
        }

        public void PauseAgents() {
            foreach (AgentProxy agent in LoadedAgents.Values) {
                if (agent.CanPause()) {
                    agent.Pause();
                } else {
                    agent.Stop();
                }
            }
        }

        public void ContinueAgents() {
            foreach (AgentProxy agent in LoadedAgents.Values) {
                if (agent.CanContinue()) {
                    agent.Continue();
                } else {
                    agent.Start();
                }
            }
        }


        public List<SecurityAgent> MergeDbInformation(List<SecurityAgent> agents) {
            List<SecurityAgent> result = new List<SecurityAgent>();
            result.AddRange(agents);
            foreach (SecurityAgent agent in this) {
                int listIndex = GetListIndex(result, agent.Name);
                SecurityAgent a = (SecurityAgent)result.Find(x => x.Id == agent.Id);
                // fallback if previous installation was made
                if (a == null) a = (SecurityAgent)result.Find(x => x.Name == agent.Name);

                if (a!=null) {
                    agent.AssemblyFilename = a.AssemblyFilename;
                    agent.Icon = a.Icon;
                    agent.SelectedIcon = a.SelectedIcon;
                    agent.UnselectedIcon = a.UnselectedIcon;
                    agent.DisplayName = a.DisplayName;
                    agent.BinaryMissing = false;
                    agent.CustomConfiguration = a.CustomConfiguration;
                    agent.LoadCustomConfig();
                    result.Remove(a);
                } else {
                    agent.Icon = global::Cyberarms.IntrusionDetection.Shared.Resources.agent15px_custom_dark;
                    agent.SelectedIcon = global::Cyberarms.IntrusionDetection.Shared.Resources.agent15px_custom_white;
                    agent.UnselectedIcon = global::Cyberarms.IntrusionDetection.Shared.Resources.agent15px_custom_dark;
                    agent.BinaryMissing = true;
                    agent.Enabled = false;
                    this.Remove(a);
                }
                //int listIndex = GetListIndex(result, agent.Name);
                //if (listIndex >= 0) {
                //    agent.AssemblyFilename = result[listIndex].AssemblyFilename;
                //    agent.Icon = result[listIndex].Icon;
                //    agent.SelectedIcon = result[listIndex].SelectedIcon;
                //    agent.UnselectedIcon = result[listIndex].UnselectedIcon;
                //    agent.DisplayName = result[listIndex].DisplayName;
                //    agent.BinaryMissing = false;
                //    agent.CustomConfiguration = result[listIndex].CustomConfiguration;
                //    agent.LoadCustomConfig();
                //    result.RemoveAt(listIndex);
                //} else {
                //    agent.Icon = global::Cyberarms.IntrusionDetection.Shared.Resources.agent15px_custom_dark;
                //    agent.SelectedIcon = global::Cyberarms.IntrusionDetection.Shared.Resources.agent15px_custom_white;
                //    agent.UnselectedIcon = global::Cyberarms.IntrusionDetection.Shared.Resources.agent15px_custom_dark;
                //    agent.BinaryMissing = true;
                //    agent.Enabled = false;
                //}
            }
            foreach (SecurityAgent agent in result) {
                agent.Enabled = false;
            }
            this.AddRange(result);
            return (List<SecurityAgent>)this;
        }

        private int GetListIndex(List<SecurityAgent> list, string name) {
            for(int i=0;i<list.Count;i++) {
                if (list[i].Name.Equals(name)) return i;
            }
            return -1;
        }

        
        
    }

}
