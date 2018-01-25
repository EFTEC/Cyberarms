using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyberarms.IntrusionDetection.Shared {
    public interface IAgentFilter {
        Guid Id { get; set; }
        string DisplayName { get; set; }
    }
}
