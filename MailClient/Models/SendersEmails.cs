using System.Collections.Generic;

namespace MailClient.Models
{
    internal class Email
    {
        private string pass;
        private string adress;

        public string Adress
        {
            get => adress;
            set => adress = value;
        }

        public string Pass
        {
            get => pass;
            set => pass = value;
        }
    }
    internal class SendersEmails
    {

        private Dictionary<string, string> sendersCollection;

        //new Dictionary<string, string>()
        //{
        //    {"artstar99@gmail.com", "132132"},
        //    {"artcore.gen@gmail.com", "5665656"}
        //};

        public Dictionary<string, string> SendersCollection
        {
            get => sendersCollection;
            set => sendersCollection = value;
        }

        public SendersEmails()
        {

        }

        public SendersEmails(Dictionary<string, string> dictionary)
        {
            sendersCollection = dictionary;
        }
    }
}
