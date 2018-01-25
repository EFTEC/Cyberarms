using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyberarms.IntrusionDetection.Shared {
    public class Globals {

        /// <summary>
        /// Application name
        /// </summary>
        public const string APPLICATION_NAME = "Cyberarms Intrusion Detection";

        /// <summary>
        /// Plugin directory name
        /// </summary>
        public const string PLUGIN_DIRECTORY_NAME = "Plugins";

        /// <summary>
        /// Windows firewall group name of blocking rules
        /// </summary>
        public const string CYBERARMS_WINDOWS_IDS_GROUP_NAME = "Cyberarms Intrusion Detection";
        /// <summary>
        /// Windows firewall rule name for all blocked clients
        /// </summary>
        public const string CYBERARMS_WINDOWS_IDS_RULE_NAME = "Blocked by Cyberarms Intrusion Detection";
        /// <summary>
        /// Windows event log source name forIntrusion Detectionlogs
        /// </summary>
        public const string CYBERARMS_WINDOWS_EVENT_SOURCE = "Cyberarms Intrusion Detection";
        /// <summary>
        /// Windows event log name forIntrusion Detectionlogs. 
        /// </summary>
        public const string CYBERARMS_WINDOWS_EVENT_LOG_NAME = "Cyberarms";


        // Event Log Information

        /// <summary>
        /// Windows event log category for configuration errors and information
        /// </summary>
        public const short CYBERARMS_LOG_CATEGORY_CONFIGURATION = 1000;

        public const short CYBERARMS_LOG_CATEGORY_SECURITY = 1001;

        public const short CYBERARMS_LOG_CATEGORY_PLUGIN = 1200;

        public const short CYBERARMS_LOG_CATEGORY_RUNTIME = 1400;


        public const int CYBERARMS_EVENT_ID_INFORMATION = 1000;
        /// <summary>
        /// Windows event log
        /// </summary>
        public const int CYBERARMS_EVENT_ID_FIREWALL_RULE_CREATED = 4001;

        public const int CYBERARMS_EVENT_ID_FIREWALL_RULE_ALTERED = 4002;

        /// <summary>
        /// A file cannot be saved to disk
        /// </summary>
        public const int CYBERARMS_EVENT_ID_PERSISTANCE_ERROR = 5000;

        /// <summary>
        /// Windows event log id for configuration file not found
        /// </summary>
        public const int CYBERARMS_EVENT_ID_CONFIGURATION_ERROR = 9000;

        /// <summary>
        /// Event log id when calling delegate with invalid parameters 
        /// </summary>
        public const int CYBERARMS_EVENT_ID_INVALID_FUNCTION_CALL = 9001;

        /// <summary>
        /// Windows event log id for plugin error
        /// </summary>
        public const int CYBERARMS_EVENT_ID_PLUGIN_ERROR = 9002;

        /// <summary>
        /// Windows event log id for plugin error during initialisation
        /// </summary>
        public const int CYBERARMS_EVENT_ID_PLUGIN_LOAD_ERROR = 9003;



    }
}
