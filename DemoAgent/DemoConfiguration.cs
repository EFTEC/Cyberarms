using System;
using Cyberarms.IntrusionDetection.Api.Plugin;

namespace DemoAgent {
    /// <summary>
    /// CustomIntrusion Detectionagent configuration 
    /// In this simple demonstration, just one property "DirectoryName" is used. 
    /// You can provide a more complex configuration class, based on your needs
    /// </summary>
    public class DemoConfiguration : PluginConfiguration {
        /// <summary>
        /// The directory which is used by the DemoAgent to watch for changes
        /// </summary>
        public string DirectoryName { get; set; }
    }
}
