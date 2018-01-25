using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyberarms.IntrusionDetection.Shared {
    public class AgentFilter : IAgentFilter {
        public AgentFilter() {
        }
        public AgentFilter(Guid id, string displayName) {
            Id = id;
            DisplayName = displayName;
        }
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
    }
}
