using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient.Infrastructure
{
    class RelayCommand:BaseCommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public override bool CanExecute(object parameter)=> canExecute?.Invoke(parameter) ?? true;
        public override void Execute(object parameter)=> execute(parameter);
        

        public RelayCommand(Action<object> Execute, Func<object,bool> CanExecute =null)
        {
            execute = Execute?? throw new ArgumentNullException(nameof(Execute));
            canExecute = CanExecute;
        }
    }
}
