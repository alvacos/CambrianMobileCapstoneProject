using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CambrianMobileCapstoneProject.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _buttonText;
        private int _count;

        public string ButtonText
        {
            get => _buttonText;
            set
            {
                _buttonText = value;
                OnPropertyChanged();
            }
        }

        public ICommand CounterCommand { get; }

        public MainPageViewModel()
        {
            _count = 0;
            ButtonText = "Click me";

            CounterCommand = new Command(OnCounterClicked);
        }

        private void OnCounterClicked()
        {
            _count++;
            ButtonText = _count == 1 ? $"Clicked {_count} time" : $"Clicked {_count} times";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

