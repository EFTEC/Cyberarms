using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyberarms.IntrusionDetection {
    internal class ClientOperationInformation {
        internal string IpAddress { get; set; }
        internal Exception Exception { get; set; }
        internal string Message { get; set; }
        internal bool HasError { get; set; }
        internal Guid AgentId { get; set; }
    }
}
