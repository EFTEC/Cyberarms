using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyberarms.IntrusionDetection.Api.Plugin {
    /// <summary>
    /// Event handler for sending intrusion attempts to theIntrusion DetectionService
    /// </summary>
    /// <param name="sender">The agent itself</param>
    /// <param name="data">Intrusion notification details</param>
    public delegate void AttackDetectedHandler(object sender, INotificationEventArgs data);
    /// <summary>
    /// Interface for agents, must be implemented to create aIntrusion Detectionagent
    /// </summary>
    public interface IAgentPlugin {        
        /// <summary>
        /// The AttackDetected Event, using AttackDetectedHandler
        /// </summary>
        /// <seealso cref="AttackDetectedHandler"/>
        event AttackDetectedHandler AttackDetected;
        /// <summary>
        /// Agent start command, is called when the service starts
        /// </summary>
        void Start();
        /// <summary>
        /// Agent stop command, is called when the service stops
        /// </summary>
        void Stop();
        /// <summary>
        /// Agent pause command, is called when the service is paused
        /// </summary>
        void Pause();
        /// <summary>
        /// Agent continue command to resume from pause
        /// </summary>
        void Continue();
        /// <summary>
        /// Returns if the agent supports pause
        /// </summary>
        /// <returns></returns>
        bool CanPause();
        /// <summary>
        /// Returns if the agent can be continued at this time
        /// </summary>
        /// <returns></returns>
        bool CanContinue();
        /// <summary>
        /// Returns if the agent is in paused state
        /// </summary>
        bool IsPaused { get; set; }
        /// <summary>
        /// Returns if the agent is in the running state
        /// </summary>
        bool IsRunning { get; }
        /// <summary>
        /// Agent configuration, usually AgentConfigurationBase, which can be used by the administration program by default without any alteration
        /// </summary>
        IAgentConfiguration Configuration { get; set; }
    }
}
