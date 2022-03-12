using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab19._1WpfApp4
{
    class RelayCommand1 : ICommand
    {
        private readonly Action<object> execute; // поля
        private readonly Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value; //передали внутреней системе Wpf, которое вызывает обработку события в тот момент который считает подходящим
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand1(Action<object> Execute, Func<object, bool> CanExecute = null)  // конструктор который принимает два делегата
        {
            execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            canExecute = CanExecute;
        }

        public bool CanExecute(object parameter) => canExecute?.Invoke(parameter) ?? true; 
        
        public void Execute(object parameter) => execute(parameter);
       
    }
}
