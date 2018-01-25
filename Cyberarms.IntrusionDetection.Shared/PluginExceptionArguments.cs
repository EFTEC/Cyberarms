using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyberarms.IntrusionDetection.Shared {
    public enum PluginExceptionSource {
        Init = 0,
        Load = 100,
        Configuration = 200,
        ServiceAction = 300,
        ExecuteAction = 400,
        Unload = 500
    }

    public class PluginExceptionArguments {
        public string AssemblyName { get; set; }
        public string ModuleName { get; set; }
        public Exception Exception { get; set; }
        public PluginExceptionSource Source { get; set; }
    }
}
