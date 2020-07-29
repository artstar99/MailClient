using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient.Data
{
    public static class SmtpData
    {
        private static int gmailPort = 587;
        private static string gmailHost = "smtp.gmail.com";

        public static string GmailHost
        {
            get => gmailHost;
            set => gmailHost = value;
        }

        public static int GmailPort
        {
            get => gmailPort;
            set => gmailPort = value;
        }
    }
}
