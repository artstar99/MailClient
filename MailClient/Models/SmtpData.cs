using System.Collections;
using System.Collections.Generic;

namespace MailClient.Models
{
    internal class SmtpData
    {
        //private int port = 587;
        //private string host = "smtp.gmail.com";
        private int port;
        private string host;

        //private Dictionary<string, int> smtpEntry;


        //public Dictionary<string, int> SmtpEntry
        //{
        //    get => smtpEntry;
        //    set => smtpEntry = value;
        //}

        public string Host
        {
            get => host;
            set => host = value;
        }

        public int Port
        {
            get => port;
            set => port = value;
        }

        public SmtpData(string host, int port)
        {
            this.host = host;
            this.port = port;

        }
    }

    internal class SmtpCollection
    {
        public string Name { get; set; }
        public ICollection<SmtpData> SmtpDataCollection { get; set; }

    }
}
