using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Cyberarms.IntrusionDetection.Shared;

namespace Cyberarms.IntrusionDetection.Admin {
    public partial class CyberarmsSecurityLog : UserControl {

        public event EventHandler FilterSelectionChanged;
        public const string ALL_AGENTS = "{46DD5CAD-3F50-4D69-8917-11505DB10553}";


        private DataSet _intrusionLog;
        public DataSet DataSetIntrusionLog {
            get {
                if (_intrusionLog == null) {
                    _intrusionLog = new DataSet();
                    _intrusionLog.Tables.Add("IntrusionLog");
                    _intrusionLog.Tables["IntrusionLog"].Columns.Add("Id", typeof(int));
                    _intrusionLog.Tables["IntrusionLog"].Columns.Add("Action", typeof(int));
                    _intrusionLog.Tables["IntrusionLog"].Columns.Add("Agent", typeof(String));
                    _intrusionLog.Tables["IntrusionLog"].Columns.Add("LogIcon", typeof(Image));
                    _intrusionLog.Tables["IntrusionLog"].Columns.Add("LogType", typeof(String));
                    _intrusionLog.Tables["IntrusionLog"].Columns.Add("EventDate", typeof(DateTime));
                    _intrusionLog.Tables["IntrusionLog"].Columns.Add("IpAddress", typeof(String));
                    _intrusionLog.Tables["IntrusionLog"].Columns.Add("Message", typeof(String));
                    _intrusionLog.Tables["IntrusionLog"].Columns.Add("AgentId", typeof(String));
                    _intrusionLog.Tables["IntrusionLog"].Columns.Add("NumberOfEvents", typeof(int));
                }
                return _intrusionLog;
            }
            set {
                _intrusionLog = value;
            }
        }

        private DataView _intrusionLogView;
        public DataView IntrusionLogView {
            get {
                if (_intrusionLogView == null) {
                    _intrusionLogView = new DataView(DataSetIntrusionLog.Tables["IntrusionLog"]);
                    _intrusionLogView.Sort = "EventDate desc";
                }
                return _intrusionLogView;
            }
        }


        public CyberarmsSecurityLog() {
            InitializeComponent();
            comboBoxAgentSelection.DisplayMember = "DisplayName";
            comboBoxAgentSelection.ValueMember = "Id";
            comboBoxAgentSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAgentSelection.Items.Add(new AgentFilter(new Guid(ALL_AGENTS), "All agents"));
            comboBoxAgentSelection.SelectedIndex = 0;
            comboBoxAgentSelection.SelectionChangeCommitted += new EventHandler(comboBoxAgentSelection_SelectionChangeCommitted);
            dataGridViewIntrusionLog.AutoGenerateColumns = false;
            dataGridViewIntrusionLog.DataSource = IntrusionLogView;
            //dataGridViewIntrusionLog.DataMember = "IntrusionLog";            
            dataGridViewIntrusionLog.Columns["LogIcon"].DataPropertyName = "LogIcon";
            dataGridViewIntrusionLog.Columns["LogType"].DataPropertyName = "LogType";
            dataGridViewIntrusionLog.Columns["LatestEntry"].DataPropertyName = "EventDate";
            dataGridViewIntrusionLog.Columns["IpAddress"].DataPropertyName = "IpAddress";
            dataGridViewIntrusionLog.Columns["Agent"].DataPropertyName = "Message";
            dataGridViewIntrusionLog.Columns["AgentId"].DataPropertyName = "AgentId";
            dataGridViewIntrusionLog.Columns["NumberOfEvents"].DataPropertyName = "NumberOfEvents";

            this.FilterSelectionChanged += new EventHandler(CyberarmsSecurityLog_FilterSelectionChanged);
            PositionLabels();
        }

        void CyberarmsSecurityLog_FilterSelectionChanged(object sender, EventArgs e) {
            // @ToDo: Filter richtig setzen!
            List<string> filter = new List<string>();
            if (!checkBoxFailedLogins.Checked && !checkBoxHardLocks.Checked && !checkBoxSoftLocks.Checked && !checkBoxSystemMessages.Checked) filter.Add("0=1");
            if (checkBoxFailedLogins.Checked) filter.Add("(Action >99 and Action <200)");
            if (checkBoxSoftLocks.Checked) filter.Add("(Action >199 and Action <300)");
            if (checkBoxHardLocks.Checked) filter.Add("(Action >299 and Action <400)");
            if (checkBoxSystemMessages.Checked) filter.Add("(Action >= 500)");

            int i = 0;
            string viewFilter = filter.Count > 0 ? "(" : String.Empty;

            foreach (string f in filter) {
                if (i > 0) viewFilter = viewFilter + " or ";
                viewFilter = viewFilter + f;
                i++;
            }
            if (filter.Count > 0) viewFilter = viewFilter + ")";
            if (comboBoxAgentSelection.Text != null && !((IAgentFilter)comboBoxAgentSelection.SelectedItem).Id.Equals(new Guid(ALL_AGENTS))) {
                viewFilter = viewFilter + (filter.Count > 0 ? " and " : "");
                viewFilter = viewFilter + (String.Format("AgentId='{0}'", ((SecurityAgent)comboBoxAgentSelection.SelectedItem).Id));
            }
            IntrusionLogView.RowFilter = viewFilter;
        }

        void comboBoxAgentSelection_SelectionChangeCommitted(object sender, EventArgs e) {

        }

        public DataRow AddLogEntry(int id, int action, string agentId, Image logIcon, string logType, DateTime eventDate, string ipAddress, string message) {
            DataTable t = DataSetIntrusionLog.Tables["IntrusionLog"];
            DataRow row;
            DataRow[] rows = t.Select(String.Format("AgentId='{0}' and IpAddress='{1}' and logType='{2}' and action='{3}'", agentId, ipAddress, logType, action));
            if (rows != null && rows.Length > 0) {
                rows[0]["NumberOfEvents"] = int.Parse(rows[0]["NumberOfEvents"].ToString()) + 1;
                rows[0]["EventDate"] = eventDate;
                row = rows[0];
            } else {
                row = t.Rows.Add(id, action,
                    SecurityAgents.Instance.GetDisplayName(agentId), logIcon, logType, eventDate, ipAddress, message, agentId, 1);
            }
            labelEventsCount.Text = CountEvents().ToString();
            if (MaxLogId < id) MaxLogId = id;
            return row;
        }

        private int CountEvents() {
            int result = 0;
            foreach (DataGridViewRow row in dataGridViewIntrusionLog.Rows) {
                int c;
                if (int.TryParse(row.Cells["NumberOfEvents"].Value.ToString(), out c)) {
                    result += c;
                }
            }
            return result;
        }

        public DataRow FillLogEntry(int maxId, int action, string agentId, Image logIcon, string logType, DateTime lastEventDate, string ipAddress, string message, int numberOfEvents) {
            DataRow row = AddLogEntry(maxId, action, agentId, logIcon, logType, lastEventDate, ipAddress, message);
            row["NumberOfEvents"] = numberOfEvents;
            labelEventsCount.Text = CountEvents().ToString();
            return row;
        }

        public int MaxLogId { get; set; }

        public void AddAgent(SecurityAgent agent) {
            comboBoxAgentSelection.Items.Add(agent);
        }

        public void RemoveAgent(SecurityAgent agent) {
            try {
                comboBoxAgentSelection.Items.Remove(agent);
            } catch {
                // not found
            }
        }

        private void dataGridViewIntrusionLog_Resize(object sender, EventArgs e) {
            PositionLabels();
        }

        private void PositionLabels() {
            smartLabelType.Left = 3;
            smartLabelLatestEntry.Left = smartLabelType.Left + dataGridViewIntrusionLog.Columns[0].Width + dataGridViewIntrusionLog.Columns[1].Width;
            smartLabelNumberOfEvents.Left = smartLabelLatestEntry.Left + dataGridViewIntrusionLog.Columns[2].Width;
            smartLabelpAddress.Left = smartLabelNumberOfEvents.Left + dataGridViewIntrusionLog.Columns[3].Width;
            smartLabelMessage.Left = smartLabelpAddress.Left + dataGridViewIntrusionLog.Columns[4].Width;
        }




    }
}
