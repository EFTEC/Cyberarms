using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Reflection;

namespace Cyberarms.IntrusionDetection.Api.Plugin {
    /// <summary>
    /// Base class for plugin configuration settings
    /// </summary>
    public class PluginConfiguration {
        /// <summary>
        /// Clone from another PluginConfiguration of the same type
        /// </summary>
        /// <param name="source"></param>
        public void CloneFrom(PluginConfiguration source) {
            foreach (PropertyInfo pi in this.GetType().GetProperties()) {
                if (pi.CanWrite) {
                    pi.SetValue(this, pi.GetValue(source, null), null);
                }
            }
        }
        
    }
}
