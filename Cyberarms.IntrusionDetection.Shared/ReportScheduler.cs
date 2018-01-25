using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Cyberarms.IntrusionDetection.Shared {
    public class ReportScheduler {
        Timer reporter;

        public event EventHandler RunDailyReport;
        public event EventHandler RunWeeklyReport;
        public event EventHandler RunMonthlyReport;

        private ReportScheduler() {
        }

        private static ReportScheduler _instance;
        public static ReportScheduler Instance {
            get {
                if (_instance == null) {
                    _instance = new ReportScheduler();
                    _instance.Init();
                }
                return _instance;
            }
            set {
                _instance = value;
            }
        }

        private void Init() {
            reporter = new Timer(600000);
            reporter.Elapsed += new ElapsedEventHandler(reporter_Elapsed);
        }

        public void StartReporting() {
            reporter.Start();
        }

        void reporter_Elapsed(object sender, ElapsedEventArgs e) {
            NotificationSettings.Instance.Reload();
            if (NotificationSettings.Instance.SummaryReportDaily) CheckDailyReport();
            if (NotificationSettings.Instance.SummaryReportWeekly) CheckWeeklyReport();
            if (NotificationSettings.Instance.SummaryReportMonthly) CheckMonthlyReport();
        }

        public void CheckDailyReport() {
            NotificationSettings.Instance.Reload();
            DateTime d = DateTime.Now.AddDays(-1);
            string dailyReportTime = String.Format("{0}-{1}-{2}", d.Year, d.Month, d.Day);
            if (!string.Equals(dailyReportTime, NotificationSettings.Instance.LastDailyReport)) {
                // run daily report
                NotificationSettings.Instance.LastDailyReport = dailyReportTime;
                NotificationSettings.Instance.Save();
                if (RunDailyReport != null) RunDailyReport(this, EventArgs.Empty);
            }
        }

        public void CheckWeeklyReport() {
            NotificationSettings.Instance.Reload();
            DateTime d = DateTime.Now.AddDays(-1);
            string weeklyReportTime = GetWeekOfYearString(d);
            if (GetWeekOfYear(d) != GetWeekOfYear(DateTime.Now) && !string.Equals(weeklyReportTime, NotificationSettings.Instance.LastWeeklyReport)) {
                // run weekly report
                NotificationSettings.Instance.LastWeeklyReport = weeklyReportTime;
                NotificationSettings.Instance.Save();
                if (RunWeeklyReport != null) RunWeeklyReport(this, EventArgs.Empty);
            }
        }

        public void CheckMonthlyReport() {
            NotificationSettings.Instance.Reload();
            DateTime d = DateTime.Now.AddDays(-1);
            string monthlyReportTime = String.Format("{0}-{1}", d.Year, d.Month);
            if (d.Month != DateTime.Now.Month && !String.Equals(monthlyReportTime, NotificationSettings.Instance.LastMonthlyReport)) {
                // run monthly report
                NotificationSettings.Instance.LastMonthlyReport = monthlyReportTime;
                NotificationSettings.Instance.Save();
                if (RunMonthlyReport != null) RunMonthlyReport(this, EventArgs.Empty);
            }
        }

        public string GetWeekOfYearString(DateTime d) {
            int weekOfYear = GetWeekOfYear(d);
            int year = d.Year;
            if (weekOfYear > 50 && d.Month < 2) year--;
            return String.Format("{0}-{1}", year, weekOfYear);
        }

        public int GetWeekOfYear(DateTime d) {
            System.Globalization.GregorianCalendar cal = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
            int weekOfYear = cal.GetWeekOfYear(d, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekOfYear;
        }

    }
}
