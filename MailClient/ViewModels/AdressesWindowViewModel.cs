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
        private string filterText;
        private ObservableCollection<Emaildb> emailsOutput;

        public ObservableCollection<Emaildb> Emails
        {
            get { return emails; }
            set
            {
                if (Equals(emails, value)) return;
                emails = value;
                //emailsOutput = value;
                OnPropertyChanged();
               //  OnPropertyChanged(nameof(EmailsOutput));
            }
        }

        public ObservableCollection<Emaildb> EmailsOutput
        {
            get
            {
                return emailsOutput;
            }
            set
            {
                if (Equals(emailsOutput, value)) return;
                    emailsOutput = value;
                    OnPropertyChanged();
            }
        }


        public string FilterText
        {
            get => filterText;
            set
            {
                if (filterText == value) return;
                filterText = value;
                OnPropertyChanged();
                var query = from e in Emails
                            where e.email.Contains(FilterText) || e.name.Contains(FilterText)
                            select e;
                emailsOutput = new ObservableCollection<Emaildb> (query);

                OnPropertyChanged(nameof(EmailsOutput));
                
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
            Emails.Remove(Selected);
            EmailsOutput.Remove(Selected);
            //Synchronize();

        }
        #endregion

        public ICommand AddEntryCommand { get; }
        private bool CanAddEntryCommandExecute(object p)
        {
            return (!String.IsNullOrEmpty(NewEntryEmail) && !String.IsNullOrEmpty(NewEntryName));
        }

        private void OnAddEntryCommandExecuted(object p)
        {
            Synchronize();
           
            Emaildb entry =
                new Emaildb
                {
                    Id = emails.Count + 1,
                    email = NewEntryEmail,
                    name = NewEntryName
                };

            emailDb.AddEntry(entry);
            Emails.Add(entry);
            NewEntryEmail = "";
            NewEntryName = "";
            //emailDb.RemoveEntry(Selected);
            //Emails.RemoveAt(Selected.Id - 1);

        }


        private void Synchronize()
        {
            filterText = null;
            emailsOutput = emails;
            OnPropertyChanged(nameof(EmailsOutput));
            OnPropertyChanged(nameof(FilterText));

        }

        public AdressesWindowViewModel()
        {
            emailDb = new EmailDataBase();
            emails = emailDb.GetEmails();
            emailsOutput = emails;

            AddEntryCommand = new RelayCommand(OnAddEntryCommandExecuted, CanAddEntryCommandExecute);
            RemoveEmailItemCommand = new RelayCommand(OnRemoveEmailItemCommandExecuted, CanRemoveEmailItemCommandExecute);


        }
    }
}
