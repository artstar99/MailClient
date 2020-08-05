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

    //TODO 1: Добавление имейлов в базу данных ++++++++++++++
    //TODO 2: Верификация ввода даннх
    //TODO 3: Поиск по адресам рассылки 
    //TODO 4: Создание списков рассылки
    //TODO 5: Добавление ввода пароля для почты отправителя
    //TODO 6: Добавление базы данных для хранения паролей и почты (добавление пользователей)

    class MainWindowViewModel : BaseViewModel
    {
        private string title = "MyMailClient";
        private SendersEmails sendersEmailsData;
        private ObservableCollection<SmtpData> smtpDataCollection;
        private Window adressesWindow;

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
        public SendersEmails SendersEmailsData
        {
            get => sendersEmailsData;
            set
            {
                if (Equals(sendersEmailsData, value)) return;
                sendersEmailsData = value;
                OnPropertyChanged();
            }
        }

        /// <summary> Данные Smtp Серверов </summary>
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

        #region OpenAdressesWindowCommand
        public ICommand OpenAdressesWindowCommand { get; }
        private bool CanOpenAdressesWindowCommandExecute(object p) => true;
        private void OnOpenAdressesWindowCommandExecuted(object p)
        {
            adressesWindow = new AdressesWindow();
            adressesWindow.ShowDialog();
        }

        #endregion

        public MainWindowViewModel()
        {
            CloseApplicationCommand = new RelayCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            OpenAdressesWindowCommand = new RelayCommand(OnOpenAdressesWindowCommandExecuted, CanOpenAdressesWindowCommandExecute);


            #region Список адресов отправителей

            var dic = new Dictionary<string, string>()
            {
                {"artstar99@gmail.com", "132132"},
                {"artcore.gen@gmail.com", "5665656"}
            };

            sendersEmailsData = new SendersEmails(dic);

            #endregion

            #region Список Smtp серверов с портами

            var gmailData = new SmtpData("smtp.gmail.com", 587);


            SmtpDataCollection = new ObservableCollection<SmtpData>() {gmailData};


            #endregion



        }
    }

}