using System.Collections.ObjectModel;
using System.Linq;
using MailClient.Data;

namespace MailClient.Models
{
    internal class EmailDataBase
    {
        private readonly EmailsDataContext emailsDataContext = new EmailsDataContext();
        private ObservableCollection<Emaildb> emails;

        public ObservableCollection<Emaildb> GetEmails() => 
            new ObservableCollection<Emaildb>(emailsDataContext.Emaildb);

         


        public void RemoveEntry(Emaildb email)
        {

            if (email == null) return;
                emailsDataContext.Emaildb.DeleteOnSubmit(email);
                emailsDataContext.SubmitChanges();

        }

        public void AddEntry(Emaildb email)
        {
            if (email == null)return;
            if (emailsDataContext.Emaildb.Contains(email)) return;
            emailsDataContext.Emaildb.InsertOnSubmit(email);
            emailsDataContext.SubmitChanges();
        }

        //public int AddEmail(Emaildb email)
        //{
        //    if (emailsDataContext.Emaildb.Contains(email)) return email.Id;
        //    emailsDataContext.Emaildb.InsertOnSubmit(email);
        //    emailsDataContext.SubmitChanges();
        //    return email.Id;
        //}

    }
}
