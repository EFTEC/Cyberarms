using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyberarms.IntrusionDetection.Api.Plugin {
    /// <summary>
    /// Custom attribute for plugins to specify displayname and description. 
    /// TheIntrusion Detectionadministration software displays the values defined as class attribute
    /// </summary>
    public class PluginAttribute : Attribute {
        /// <summary>
        /// This attribute is displayed in theIntrusion Detectionadministration software
        /// </summary>
        /// <param name="displayName">Name to display in the administration software</param>
        /// <param name="description">Short description of the agent</param>
        /// <param name="version">Version number of the agent</param>
        public PluginAttribute(string displayName, string description, string version)
            : this(displayName, description) {
                this.Version = version;
        }

        /// <summary>
        /// This attribute is displayed in theIntrusion Detectionadministration software
        /// </summary>
        /// <param name="displayName">Name to display in the administration software</param>
        /// <param name="description">Short description of the agent</param>
        public PluginAttribute(string displayName, string description)
            : this(displayName) {
            this.Description = description;
        }
        /// <summary>
        /// This attribute is displayed in theIntrusion Detectionadministration software
        /// </summary>
        /// <param name="displayName">Name to display in the administration software</param>
        public PluginAttribute(string displayName) {
            this.DisplayName = displayName;
        }
        /// <summary>
        /// Display name of your agent
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Add a short description about what your agent does
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Version number of your agent
        /// </summary>
        public string Version { get; set; }
    }
}
