using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyberarms.IntrusionDetection.Api.Plugin {
    public interface INetworkListener {
        long TotalPackets { get; set; }
    }
}
