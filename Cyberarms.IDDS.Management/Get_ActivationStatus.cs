using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyberarms.IntrusionDetection.Shared;

namespace Cyberarms.IDDS.Management {
    [System.Management.Automation.Cmdlet(System.Management.Automation.VerbsCommon.Get, "ActivationStatus")]
    public class Get_ActivationStatus : System.Management.Automation.PSCmdlet {
        [System.Management.Automation.Parameter(Position = 0, Mandatory = false)]
        public string Options;

        protected override void ProcessRecord() {
            if (String.IsNullOrEmpty(Options)) {
                this.WriteObject(System.Reflection.Assembly.GetExecutingAssembly().Location);
                
            } else {
                switch (Options) {
                    case "-v":
                        break;
                }
            }
        }

    }
}
