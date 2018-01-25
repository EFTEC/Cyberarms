using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Reflection;



namespace Cyberarms.WebSecurity {
    public class SecurityMonitor : IHttpModule {
        const string VAR_NAME_FAILED_LOGIN_RDWEB = "bFailedLogon";
        const string VAR_NAME_FAILED_LOGIN_DEFAULT = "bCyberarmsLoginFailed";
        const string EVENT_LOG_MESSAGE = "Cyberarms Web Security Monitor has recognized an unsuccessful login from computer {0} [IP = '{1}'] \nUser agent: {2}\nRequested url: {3}";
        
        public void Dispose() {

        }


        public void Init(HttpApplication context) {
            context.PostRequestHandlerExecute += context_PostRequestHandlerExecute;
        }

        void context_PostRequestHandlerExecute(object sender, EventArgs e) {
            try {
                bool bFailedLoginDetected = false;
                if (sender != null) {
                    HttpContext context = ((HttpApplication)sender).Context;
                    if (context != null) {
                        IHttpHandler handler = ((HttpApplication)sender).Context.Handler;
                        foreach (FieldInfo fi in handler.GetType().GetFields()) {
                            if (fi.Name == VAR_NAME_FAILED_LOGIN_DEFAULT || fi.Name == VAR_NAME_FAILED_LOGIN_RDWEB) {
                                bool bFailed = false;
                                if (fi.GetValue(handler) != null && bool.TryParse(fi.GetValue(handler).ToString(), out bFailed)) {
                                    if (bFailed) bFailedLoginDetected = true;
                                }
                            }
                        }
                        if (bFailedLoginDetected) {
                            // write login failed to application event log
                            System.Diagnostics.EventLog.WriteEntry("Application",
                                String.Format(EVENT_LOG_MESSAGE, context.Request.UserHostName, context.Request.UserHostAddress, context.Request.UserAgent, context.Request.Url),
                                System.Diagnostics.EventLogEntryType.FailureAudit, 4625);
                        }
                    }
                }
            } catch {
                // avoid errors caused by this module
            }
        }



    }

}
