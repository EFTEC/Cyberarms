using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace Cyberarms.IntrusionDetection.Api.Plugin {

    /// <summary>
    /// This class can be used as base class for custom configuration.
    /// Using this base class,Intrusion Detectionautomatically loads and saves configuration values needed by your plugin.
    /// </summary>
    public class AgentConfigurationBase : IAgentConfiguration {
        /// <summary>
        /// The name of your assembly, this property is used byIntrusion Detectionand is set automatically when adding your plugin toIntrusion Detectionplugins
        /// </summary>
        public string AssemblyName { get; set; }
        /// <summary>
        /// The name of your agent, used by Intrusion Detection
        /// </summary>
        public string AgentName { get; set; }
        /// <summary>
        /// Is used to check if the agent should be loaded by IntrusionDetection. This value is set by theIntrusion Detectionadministration software
        /// </summary>
        public bool Enabled { get; set; }
        
         
        private PluginConfiguration _agentSettings;
        /// <summary>
        /// Agent settings containing your custom settings. This must be marked with the System.Xml.Serialization.XmlIgnore() attribute,
        /// and the property must ensure to return the right configuration for the plugin.
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public PluginConfiguration AgentSettings {
            get {
                if (_agentSettings == null && !String.IsNullOrEmpty(ConfigurationSettingsTypeName)) {
                    try {
                        Type configType = GetConfigurationType();
                        if (configType != null) {
                            object o = Activator.CreateInstance(configType);
                            /*if (String.IsNullOrEmpty((o as IAgentConfiguration).ConfigurationSettingsTypeName)) {
                                (o as IAgentConfiguration).ConfigurationSettingsTypeName = ConfigurationSettingsTypeName;
                            }*/

                            if (o is PluginConfiguration) {
                                _agentSettings = (PluginConfiguration)o;
                            }
                        }
                    } catch (Exception ex) {
                        throw ex;
                    }
                }
                return _agentSettings;
            }
            set {
                _agentSettings = value;
            }
        }

        /// <summary>
        /// String value of your custom configuration settings type. 
        /// </summary>
        public string ConfigurationSettingsTypeName { get; set; }

        /// <summary>
        /// Returns the configuration type
        /// </summary>
        /// <returns></returns>
        public string PluginConfigurationXml {
            get {
                if (AgentSettings == null) return null;
                XmlSerializer xs = new XmlSerializer(AgentSettings.GetType());
                StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter(sb);
                xs.Serialize(sw, AgentSettings);
                return sb.ToString();
            }
            set {
                if (AgentSettings != null) {
                    XmlSerializer xs = new XmlSerializer(AgentSettings.GetType());
                    StringReader sr = new StringReader(value);
                    try {
                        AgentSettings = (PluginConfiguration)xs.Deserialize(sr);
                    } catch (Exception ex) {
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// Override of hard lock duration
        /// </summary>
        public int HardLockDurationHrs { get; set; }
        /// <summary>
        /// Override of hard lock attempts
        /// </summary>
        public int HardLockAttempts { get; set; }
        /// <summary>
        /// Override of soft lock duration
        /// </summary>
        public int SoftLockDurationMins { get; set; }
        /// <summary>
        /// Override value for soft lock attempts
        /// </summary>
        public int SoftLockAttempts { get; set; }
        /// <summary>
        /// ConfigureIntrusion Detectionto use custom settings for this agent
        /// </summary>
        public bool OverwriteConfiguration { get; set; }
        /// <summary>
        /// Override of hard lock setting to never unlock an attacker's IP address
        /// </summary>
        public bool NeverUnlock { get; set; }
        /// <summary>
        /// The filename of an agent
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Used to clone objects
        /// </summary>
        /// <param name="source"></param>
        public void CloneFrom(IAgentConfiguration source) {
            this.AssemblyName = source.AssemblyName;
            this.AgentName = source.AgentName;
            this.ConfigurationSettingsTypeName = source.ConfigurationSettingsTypeName;
            this.Enabled = source.Enabled;
            this.HardLockAttempts = source.HardLockAttempts;
            this.HardLockDurationHrs = source.HardLockDurationHrs;
            this.SoftLockAttempts = source.SoftLockAttempts;
            this.SoftLockDurationMins = source.SoftLockDurationMins;
            this.OverwriteConfiguration = source.OverwriteConfiguration;
            this.NeverUnlock = source.NeverUnlock;
            if (!String.IsNullOrEmpty(ConfigurationSettingsTypeName) && source.AgentSettings != null) {
                AgentSettings = (PluginConfiguration)Activator.CreateInstance(GetConfigurationType());
                this.AgentSettings.CloneFrom(source.AgentSettings);
            }


        }

        /// <summary>
        /// Returns the type of custom configuration
        /// </summary>
        /// <returns></returns>
        public Type GetConfigurationType() {
            if (File.Exists(this.AssemblyName)) {
                Assembly assembly = Assembly.LoadFile(this.AssemblyName);
                if (assembly != null) {
                    try {
                        foreach (Type type in assembly.GetTypes()) {
                            if (type.IsPublic && !type.IsAbstract) {
                                if (type.FullName == this.ConfigurationSettingsTypeName) return type;
                            }
                        }
                    } catch (Exception ex) {
                        throw ex;
                    }
                }
            }
            return null;
        }





    }
}
