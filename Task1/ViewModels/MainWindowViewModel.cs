using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task1.Models;

namespace Task1
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double rcirc;

        public double Rcirc
        {
            get => rcirc;
            set
            {
                rcirc = value;
                OnPropertyChanged();
            }
        }


        private double lcirc;

        public double Lcirc
        {
            get => lcirc;
            set
            {
                lcirc = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }

        private void OnAddCommandExecute(object p)
        {
            Lcirc = Result . L_length(Rcirc);
        }

        private bool CanAddCommandExecuted(object p)
        {
            if (Rcirc != 0)
                return true;
            else
            {
                return false;
            }
        }

        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecuted);
        }
    }
}
