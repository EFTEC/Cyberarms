using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Cyberarms.IntrusionDetection.Api.Plugin {
    /// <summary>
    /// This interface provídes any property needed forIntrusion Detectionto load and save configuration values for your agent plugin.
    /// It is used byIntrusion Detectioninternally, as agent developer, you don't have to care about this interface
    /// </summary>
    public interface IAgentConfiguration {
        /// <summary>
        /// The name of your assembly, this property is used byIntrusion Detectionand is set automatically when adding your plugin toIntrusion Detectionplugins
        /// </summary>
        string AssemblyName { get; set; }
        /// <summary>
        /// The name of your agent, used by Intrusion Detection
        /// </summary>
        string AgentName { get; set; }
        /// <summary>
        /// Is used to check if the agent should be loaded by IntrusionDetection. This value is set by theIntrusion Detectionadministration software
        /// </summary>
        bool Enabled { get; set; }
        /// <summary>
        /// Agent settings containing your custom settings
        /// </summary>
        PluginConfiguration AgentSettings { get; set; }
        /// <summary>
        /// String value of your custom configuration settings type. 
        /// </summary>
        string ConfigurationSettingsTypeName { get; set; }
        /// <summary>
        /// Returns the configuration type
        /// </summary>
        /// <returns></returns>
        Type GetConfigurationType();
        /// <summary>
        /// Override value for soft lock attempts
        /// </summary>
        int SoftLockAttempts { get; set; }
        /// <summary>
        /// Override of hard lock attempts
        /// </summary>
        int HardLockAttempts { get; set; }
        /// <summary>
        /// Override of soft lock duration
        /// </summary>
        int SoftLockDurationMins { get; set; }
        /// <summary>
        /// Override of hard lock duration
        /// </summary>
        int HardLockDurationHrs { get; set; }
        /// <summary>
        /// Override of hard lock setting to never unlock an attacker's IP address
        /// </summary>
        bool NeverUnlock { get; set; }
        /// <summary>
        /// ConfigureIntrusion Detectionto use custom settings for this agent
        /// </summary>
        bool OverwriteConfiguration { get; set; }
        /// <summary>
        /// Used to clone objects
        /// </summary>
        /// <param name="source"></param>
        void CloneFrom(IAgentConfiguration source);
    }
}
