using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyberarms.Agents.MailServer {

    public enum Pop3Message {
        None,
        APOP,
        DELE, 
        LIST,
        NOOP,
        PASS,
        QUIT, 
        RETR, 
        RSET, 
        STAT,
        TOP,
        UIDL,
        USER
    }
    
    public class Pop3Client {
        public Pop3Message LastMessage { get; set; }
        public DateTime LastInteraction { get; set; }
    }
}
