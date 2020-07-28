using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MailClient.Annotations;

namespace MailClient.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        private double halfWindowSize;
        private string title = "MyMailClient";

        /// <summary> Заголовок окна </summary>
        public string Title
        {
            get => title;
            set
            {
                if (Equals(title, value)) return;
                else
                {
                    title = value;
                    OnPropertyChanged();
                }
            }
        }

        //Сделать свойство для высоты окна 



        /// <summary> Высота RichTextBox'a </summary>
        //public double HalfWindowSize
        //{
        //    get => halfWindowSize;
        //    set => halfWindowSize = value;
        //}


    }
}
