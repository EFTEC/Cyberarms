using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyberarms.IntrusionDetection.Shared {
    public class NotificationSettings {
        public const string NOTIFICATION_ON_UNLOCK = "{BE227461-8622-4168-A15C-644773070A5D}";
        public const string NOTIFICATION_ON_SOFT_LOCK = "{C4A9EC33-44E0-445A-8134-009F559E22A1}";
        public const string NOTIFICATION_ON_HARD_LOCK = "{AD963FA3-1D19-4CFE-9F6A-C1A8A4DBBA33}";
        public const string NOTIFICATION_SUMMARY_REPORT = "{AADCD484-483A-4CAB-AA91-8C83942AE3AB}";
        public const string NOTIFICATION_SUMMARY_REPORT_DAILY = "{92993EF9-5C9E-4E58-9250-F2EF1E838914}";
        public const string NOTIFICATION_SUMMARY_REPORT_WEEKLY = "{06191D72-17B5-488F-BB59-F6E61B4C4B42}";
        public const string NOTIFICATION_SUMMARY_REPORT_MONTHLY = "{8B0995D6-6820-4FBE-9983-4A9533FB0BFD}";
        public const string LAST_DAILY_REPORT = "{78F53752-3167-4A81-BBC2-1CEFAF3211CE}";
        public const string LAST_WEEKLY_REPORT = "{10C8A9BC-A1CA-4BD5-818C-39A4696E9C80}";
        public const string LAST_MONTHLY_REPORT = "{4D3BC893-8C13-41ED-BEF8-35BEB768C7E8}";

        private static NotificationSettings _instance;

        public static NotificationSettings Instance {
            get {
                if (_instance == null) {
                    _instance = new NotificationSettings();
                }
                return _instance;
            }
        }


        public bool OnUnlock {
            get {
                return StringToBool(IddsConfig.Instance.GetConfigValue(NOTIFICATION_ON_UNLOCK));
            }
            set {
                IddsConfig.Instance.SetConfigValue(NOTIFICATION_ON_UNLOCK, value.ToString());
            }
        }


        
        public bool OnSoftLock { 
            get {
                return StringToBool(IddsConfig.Instance.GetConfigValue(NOTIFICATION_ON_SOFT_LOCK));
            } 
            set {
                IddsConfig.Instance.SetConfigValue(NOTIFICATION_ON_SOFT_LOCK, value.ToString());
            }
        }

        public bool OnHardLock { 
            get {
                return StringToBool(IddsConfig.Instance.GetConfigValue(NOTIFICATION_ON_HARD_LOCK));
            } 
            set {
                IddsConfig.Instance.SetConfigValue(NOTIFICATION_ON_HARD_LOCK, value.ToString());
            }
        }
        public bool SummaryReport { 
            get {
                return StringToBool(IddsConfig.Instance.GetConfigValue(NOTIFICATION_SUMMARY_REPORT));
            } 
            set {
                IddsConfig.Instance.SetConfigValue(NOTIFICATION_SUMMARY_REPORT, value.ToString());
            }
        }
        public bool SummaryReportDaily { 
                get {
                return StringToBool(IddsConfig.Instance.GetConfigValue(NOTIFICATION_SUMMARY_REPORT_DAILY));
            } 
            set {
                IddsConfig.Instance.SetConfigValue(NOTIFICATION_SUMMARY_REPORT_DAILY, value.ToString());
            }
        }
        
        public bool SummaryReportWeekly { 
            get {
                return StringToBool(IddsConfig.Instance.GetConfigValue(NOTIFICATION_SUMMARY_REPORT_WEEKLY));
            } 
            set {
                IddsConfig.Instance.SetConfigValue(NOTIFICATION_SUMMARY_REPORT_WEEKLY, value.ToString());
            }
        }

        public bool SummaryReportMonthly { 
                get {
                return StringToBool(IddsConfig.Instance.GetConfigValue(NOTIFICATION_SUMMARY_REPORT_MONTHLY));
            } 
            set {
                IddsConfig.Instance.SetConfigValue(NOTIFICATION_SUMMARY_REPORT_MONTHLY, value.ToString());
            }
        }


        public string LastDailyReport {
            get {
                return IddsConfig.Instance.GetConfigValue(LAST_DAILY_REPORT);
            }
            set {
                IddsConfig.Instance.SetConfigValue(LAST_DAILY_REPORT, value);
            }
        }

        public string LastWeeklyReport {
            get {
                return IddsConfig.Instance.GetConfigValue(LAST_WEEKLY_REPORT);
            }
            set {
                IddsConfig.Instance.SetConfigValue(LAST_WEEKLY_REPORT, value);
            }
        }

        public string LastMonthlyReport {
            get {
                return IddsConfig.Instance.GetConfigValue(LAST_MONTHLY_REPORT);
            }
            set {
                IddsConfig.Instance.SetConfigValue(LAST_MONTHLY_REPORT, value);            
            }
        }


        private NotificationSettings() {

        }

        private bool StringToBool(string value) {
            bool result = false;
            bool.TryParse(value, out result);
            return result;
        }

        public void Reload() {
            IddsConfig.Instance.LoadAppConfig();
        }

        public void Save() {
            IddsConfig.Instance.SaveAppConfig();
        }
    }
}
