using Lab19._1WpfApp4.Models1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab19._1WpfApp4.ViewModels1
{
    class MainWindowViewModel1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double radius;
        public double Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }

        private double circ;
        public double Circ
        {
            get => circ;
            set
            {
                circ = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddCommand { get; }
        private void OnAddCommandExecute(object p)
        {
            Circ = Circle.Circumference(Radius);
        }
        private bool CanAddCommandExecuted(object p)// закрытый метод
        {
           if (Radius != 0)
                return true;
            else
                return
                    false;
        }

        public MainWindowViewModel1() // коструктор
        {
            AddCommand = new RelayCommand1(OnAddCommandExecute, CanAddCommandExecuted); // инициализируем команду
        }

    }
}
