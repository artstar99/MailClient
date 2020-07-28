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

        public double HalfWindowSize
        {
            get => halfWindowSize;
            set => halfWindowSize = value;
        }

      
    }
}
