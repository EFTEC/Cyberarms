using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;

namespace Cyberarms.Agents.FtpServer {
    public class AppLayerFtp {

        public const string FTP_REPLY_CODE_LOGIN_DENIED = "530";

        public string FtpReplyCode { get; set; }

        public AppLayerFtp(byte[] byBuffer, int nReceived) {
            try {
                //Create MemoryStream out of the received bytes
                MemoryStream memoryStream = new MemoryStream(byBuffer, 0, nReceived);
                //Next we create a BinaryReader out of the MemoryStream
                BinaryReader binaryReader = new BinaryReader(memoryStream);
                char[] replyCodeChars = binaryReader.ReadChars(3);
                StringBuilder replyCode = new StringBuilder();
                
                if (replyCodeChars.Length == 3) {
                    for(int i=0;i<3;i++) replyCode.Append(replyCodeChars[i]);
                }
                FtpReplyCode = replyCode.ToString();
                
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
