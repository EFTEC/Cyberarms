using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyberarms.IntrusionDetection.Api.Plugin {
    /// <summary>
    /// Notification arguments containing attacker information
    /// </summary>
    public interface INotificationEventArgs {
        /// <summary>
        /// IP address of the attacker. This can be in TCP/IP version 4 (123.123.123.123 format, dotted notation) or TCP/IP version 6 (abab:abab::1234:abcd format, 128 bits)
        /// </summary>
        string IpAddress { get; set; }
        /// <summary>
        /// Notification date
        /// </summary>
        DateTime CreateDate { get; set; }
        /// <summary>
        /// Event id, for internal purposes. You can include an own Id of forward a log event id
        /// </summary>
        int EventId { get; set; }
        /// <summary>
        /// Optionally include a message to an event listener. 
        /// </summary>
        string EventMessage { get; set; }
    }
}
