using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cyberarms.IntrusionDetection.Shared;

namespace Cyberarms.IntrusionDetection.Admin {
    public partial class CyberarmsDashboard : UserControl {
        public event EventHandler SecurityAgentConfigurationRequest;

        public CyberarmsDashboard() {
            InitializeComponent();
        }

        public void SetSoftLocks(int locks) {
            labelSoftLocks.Text = locks.ToString();
        }

        public void SetHardLocks(int locks) {
            labelHardLocks.Text = locks.ToString();
        }

        public void SetUnsuccessfulLogins(int logins) {
            labelUnsuccessfulLogins.Text = logins.ToString();
        }


        public void AddAgent(SecurityAgent agent) {
            PluginItem agentX = new PluginItem();
            agentX.SecurityAgent = agent;
            flowLayoutPanelPlugins.Controls.Add(agentX);
            agentX.SecurityAgentConfigurationRequest += new EventHandler(agentX_SecurityAgentConfigurationRequest);
        }

        void agentX_SecurityAgentConfigurationRequest(object sender, EventArgs e) {
            if (SecurityAgentConfigurationRequest != null) SecurityAgentConfigurationRequest(sender, e);
        }

        public void ClearAgents() {
            flowLayoutPanelPlugins.Controls.Clear();
        }

    }
}
