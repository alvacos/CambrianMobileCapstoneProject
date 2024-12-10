using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CambrianMobileCapstoneProject.Model;

namespace CambrianMobileCapstoneProject.ViewModel
{
    public class AddExpensePageViewModel : INotifyPropertyChanged
    {
        private NewExpense _newExpense = new();

        public event PropertyChangedEventHandler PropertyChanged;

        public NewExpense NewExpense
        {
            get => _newExpense;
            set
            {
                _newExpense = value;
                OnPropertyChanged(nameof(NewExpense));
            }
        }

        public ICommand SaveExpenseCommand => new Command(SaveExpense);

        private void SaveExpense()
        {
            if (NewExpense.Amount < 0.1)
            {
                Application.Current.MainPage.DisplayAlert("Validation Error", "Amount must be at least 0.1", "OK");
                return;
            }

            var expense = new Expense
            {
                Name = NewExpense.Name,
                Category = NewExpense.Category,
                Amount = NewExpense.Amount,
                Date = NewExpense.Date
            };

            var dbHelper = new DatabaseHelper();
            dbHelper.AddNewExpense(expense);
            Application.Current.MainPage.Navigation.PopAsync();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
