using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyberarms.IntrusionDetection.Api.Plugin;
using System.Timers;

namespace Cyberarms.IntrusionDetection.Shared {
    public class AgentProxy : MarshalByRefObject, IAgentPlugin{
        public event AttackDetectedHandler AttackDetected;

        Timer watchdog;
        TimeSpan lastCpuTime = new TimeSpan(0);
        long lastPackets;

        IAgentPlugin agent;
        public AgentProxy(string assemblyFilename, string typeName) {
            try {
                agent = (IAgentPlugin)Activator.CreateInstanceFrom(assemblyFilename, typeName).Unwrap();
            } catch (Exception ex) {
                throw ex;
            }
            agent.AttackDetected += new AttackDetectedHandler(agent_AttackDetected);
        }

        void agent_AttackDetected(object sender, INotificationEventArgs data) {
            if (this.AttackDetected != null) this.AttackDetected(sender, data);
        }


        public void Start() {
            agent.Start();
        }

        public void Stop() {
            agent.Stop();
        }

        public void Pause() {
            agent.Pause();
        }

        public void Continue() {
            agent.Continue();
        }

        public bool CanPause() {
            return agent.CanPause();
        }

        public bool CanContinue() {
            return agent.CanContinue();
        }

        public bool IsPaused {
            get {
                return agent.IsPaused;
            }
            set {
                agent.IsPaused = value;
            }
        }

        public bool IsRunning {
            get { return agent.IsRunning; }
        }

        public IAgentConfiguration Configuration {
            get {
                return agent.Configuration;
            }
            set {
                agent.Configuration = value;
            }
        }

        public long GetMemoryUsage() {
            return AppDomain.CurrentDomain.MonitoringTotalAllocatedMemorySize;
        }

        public TimeSpan GetCpuTime() {
            return AppDomain.CurrentDomain.MonitoringTotalProcessorTime;
        }

        public void EnableMonitoring() {
            watchdog = new Timer();
            watchdog.Interval = 1000;
            watchdog.Elapsed += new ElapsedEventHandler(watchdog_Elapsed);
            lastCpuTime = AppDomain.CurrentDomain.MonitoringTotalProcessorTime;
            if (agent is INetworkListener) lastPackets = (agent as INetworkListener).TotalPackets;
            watchdog.Start();
            AppDomain.MonitoringIsEnabled = true;
        }

        public List<AgentPerformanceRecord> PerformanceRecords { get; set; }

        void watchdog_Elapsed(object sender, ElapsedEventArgs e) {
            AgentPerformanceRecord rcd = new AgentPerformanceRecord();
            rcd.DateTime = DateTime.Now;
            rcd.MemoryValue = AppDomain.CurrentDomain.MonitoringTotalAllocatedMemorySize;
            rcd.CpuUsage = AppDomain.CurrentDomain.MonitoringTotalProcessorTime.Subtract(lastCpuTime);
            if (agent is INetworkListener) rcd.Packets = (agent as INetworkListener).TotalPackets - lastPackets;
            PerformanceRecords.Add(rcd);
        }

        public void DisableMonitoring() {
            watchdog = null;
        }


        public void Dispose() {
            this.Dispose();
        }

        
        

    }
}
