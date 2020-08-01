using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MailClient.Data;
using MailClient.Infrastructure;
using MailClient.Models;

namespace MailClient.ViewModels
{
    class AdressesWindowViewModel : BaseViewModel
    {
        private EmailDataBase emailDb;
        private ObservableCollection<Emaildb> emails;
        private Emaildb selected;

        public ObservableCollection<Emaildb> Emails
        {
            get { return emails; }
            set
            {
                if (Equals(emails, value))return;
                emails = value;
                OnPropertyChanged();
            }
        }

        public Emaildb Selected
        {
            get => selected;
            set
            {
                if (Equals(selected, value)) return;
                selected = value;
                OnPropertyChanged();
            }
        }

        public ICommand RemoveEmailItemCommand { get; }
        private bool CanRemoveEmailItemCommandExecute(object p) => Selected != null;
        private void OnRemoveEmailItemCommandExecuted(object p)
        {
            
            emailDb.RemoveItem(Selected);
            Emails.RemoveAt(Selected.Id - 1);

        }


        public AdressesWindowViewModel()
        {
            emailDb = new EmailDataBase();
            emails = emailDb.GetEmails();


            RemoveEmailItemCommand = new RelayCommand(OnRemoveEmailItemCommandExecuted, CanRemoveEmailItemCommandExecute);


        }
    }
}
