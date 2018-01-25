using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyberarms.IntrusionDetection.Api.Plugin {
    /// <summary>
    /// Base class for agents
    /// </summary>
    public class AgentPlugin : IAgentPlugin {
        /// <summary>
        /// The AttackDetected Event, using AttackDetectedHandler
        /// </summary>
        /// <seealso cref="AttackDetectedHandler"/>                
        public event AttackDetectedHandler AttackDetected;
        /// <summary>
        /// Initialize the agent
        /// </summary>
        public AgentPlugin() {
            this.IsPaused = false;
        }
        /// <summary>
        /// Is used to invoke all event listener delegates
        /// </summary>
        /// <param name="sender">The agent itself</param>
        /// <param name="data">Notification arguments</param>
        protected void OnAttackDetected(object sender, INotificationEventArgs data) {
            if (AttackDetected != null) {
                try {
                    AttackDetected(this, data);
                } catch (Exception ex) {
                    // throw ex; 
                    System.Diagnostics.EventLog.WriteEntry("Cyberarms.IntrusionDetection.Api.Plugin.AgentPlugin", ex.Message);
                }
            }
        }

        /// <summary>
        /// Agent start command, is called when the service starts
        /// </summary>
        public void Start() {
            if (!IsRunning) {
                try {
                    OnStartAgent();
                    IsRunning = true;
                } catch (Exception ex) {
                    throw ex;
                }
            } else {
                throw new Exception("Agent is already running. Operation cancelled!");
            }
        }

        /// <summary>
        /// Agent stop command, is called when the service stops
        /// </summary>
        public void Stop() {
            if (IsRunning) {
                try {
                    OnStopAgent();
                    IsRunning = false;
                } catch (Exception ex) {
                    throw ex;
                }
            } else {
                throw new Exception("Agent is not running.");
            }
        }


        /// <summary>
        /// Agent pause command, is called when the service is paused
        /// </summary>
        public void Pause() {
            if (CanPause()) {
                try {
                    OnPauseAgent();
                    IsPaused = true;
                } catch (Exception ex) {
                    throw ex;
                }
            } else {
                throw new Exception("Agent cannot be paused in this state");
            }
        }

        /// <summary>
        /// Agent continue command to resume from pause
        /// </summary>
        public void Continue() {
            if (CanContinue()) {
                try {
                    OnContinueAgent();
                    IsPaused = false;
                } catch (Exception ex) {
                    throw ex;
                }
            } else {
                throw new Exception("Agent must be in paused state");
            }
        }


        /// <summary>
        /// Returns if the agent supports pause
        /// </summary>
        /// <returns></returns>
        public bool CanPause() {
            return !IsPaused && IsRunning;
        }

        /// <summary>
        /// Returns if the agent can be continued at this time
        /// </summary>
        /// <returns></returns>
        public bool CanContinue() {
            return IsPaused;
        }

        /// <summary>
        /// Returns if the agent is in paused state
        /// </summary>
        public bool IsPaused { get; set; }


        /// <summary>
        /// Returns if the agent is in the running state
        /// </summary>
        public virtual bool IsRunning {
            get;
            private set;
        }

        private IAgentConfiguration _configuration;
        /// <summary>
        /// Agent configuration, usually AgentConfigurationBase, which can be used by the administration program by default without any alteration
        /// </summary>
        public IAgentConfiguration Configuration { 
            get {
                if (_configuration == null) {
                    _configuration = new AgentConfigurationBase();
                }
                return _configuration;
            }
            set{
                _configuration = value;
            }
        }

        /// <summary>
        /// Override this method to do anything required to start your agent
        /// </summary>
        protected virtual void OnStartAgent() {
        }
        /// <summary>
        /// Override this method to do anything required to pause your agent
        /// </summary>
        protected virtual void OnPauseAgent() {
        }
        /// <summary>
        /// Override this method to stop your agent
        /// </summary>
        protected virtual void OnStopAgent() {
        }
        /// <summary>
        /// Override this method to continue your agent from the paused state
        /// </summary>
        protected virtual void OnContinueAgent() {
        }


    }
}
