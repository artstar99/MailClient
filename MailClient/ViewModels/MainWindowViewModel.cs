using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MailClient.Annotations;
using MailClient.Infrastructure;
using MailClient.Models;

namespace MailClient.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        private string title = "MyMailClient";
        private EmailCollection emailCollectionData;
        private ObservableCollection<SmtpData> smtpDataCollection;

        /// <summary> Заголовок окна </summary>
        public string Title
        {
            get => title;
            set
            {
                if (Equals(title, value))
                    return;
                title = value;
                OnPropertyChanged();

            }
        }

        /// <summary> Адреса отправителей  </summary>
        public EmailCollection EmailCollectionData
        {
            get => emailCollectionData;
            set
            {
                if (Equals(emailCollectionData, value)) return;
                emailCollectionData = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<SmtpData> SmtpDataCollection
        {
            get => smtpDataCollection;
            set
            {
                if (smtpDataCollection == value) return;
                smtpDataCollection = value;
                OnPropertyChanged();
            }
        }

        #region CloseApplicationCommand

        public ICommand CloseApplicationCommand { get; }
        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p) => Application.Current.Shutdown();

        #endregion

        public ICommand OpenAdressesWindow { get; }
        private bool CanOpenAdressesWindowExecute(object p) => true;
        private void OnOpenAdressesWindowExecuted(object p) =>

        public MainWindowViewModel()
        {
            CloseApplicationCommand =
                new RelayCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);


            #region Список адресов отправителей

            var dic = new Dictionary<string, string>()
            {
                {"artstar99@gmail.com", "132132"},
                {"artcore.gen@gmail.com", "5665656"}
            };

            emailCollectionData = new EmailCollection(dic);

            #endregion

            #region Список Smtp серверов с портами

            var gmailData = new SmtpData("smtp.gmail.com", 587);


            SmtpDataCollection = new ObservableCollection<SmtpData>() {gmailData};


            #endregion



        }
    }

}