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
        private string newEntryEmail;
        private string newEntryName;

        public ObservableCollection<Emaildb> Emails
        {
            get { return emails; }
            set
            {
                if (Equals(emails, value)) return;
                emails = value;
                OnPropertyChanged();
            }
        }

        #region Текстбоксы добавления нового имейла
        public string NewEntryEmail
        {
            get => newEntryEmail;
            set
            {
                if (Equals(newEntryEmail, value)) return;
                newEntryEmail = value;
                OnPropertyChanged();
            }
        }

        public string NewEntryName
        {
            get => newEntryName;
            set
            {
                if (Equals(newEntryName, value)) return;
                newEntryName = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Выбранная в Datagrid запись
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
        #endregion

        #region RemoveEmailItemCommand
        public ICommand RemoveEmailItemCommand { get; }
        private bool CanRemoveEmailItemCommandExecute(object p) => Selected != null;
        private void OnRemoveEmailItemCommandExecuted(object p)
        {

            emailDb.RemoveEntry(Selected);
            Emails.RemoveAt(Selected.Id - 1);

        }
        #endregion

        public ICommand AddEntryCommand { get; }
        private bool CanAddEntryCommandExecute(object p)
        {
            return (NewEntryEmail!=null && NewEntryName != null && NewEntryEmail != "" && NewEntryName != "");
        }

        private void OnAddEntryCommandExecuted(object p)
        {
            Emaildb entry =
                new Emaildb
                {
                    Id = emails.Count+1,
                    email = NewEntryEmail,
                    name = NewEntryName
                };
            
            emailDb.AddEntry(entry);
            Emails.Add(entry);
            NewEntryEmail = null;
            NewEntryName = null;
            //emailDb.RemoveEntry(Selected);
            //Emails.RemoveAt(Selected.Id - 1);

        }

        public AdressesWindowViewModel()
        {
            emailDb = new EmailDataBase();
            emails = emailDb.GetEmails();

            AddEntryCommand = new RelayCommand(OnAddEntryCommandExecuted, CanAddEntryCommandExecute);
            RemoveEmailItemCommand = new RelayCommand(OnRemoveEmailItemCommandExecuted, CanRemoveEmailItemCommandExecute);


        }
    }
}
