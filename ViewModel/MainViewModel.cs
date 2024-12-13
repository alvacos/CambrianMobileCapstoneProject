using CambrianMobileCapstoneProject.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambrianMobileCapstoneProject.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly DatabaseHelper databaseHelper;

        [ObservableProperty]
        ObservableCollection<Expense> expenses;

        [ObservableProperty]
        Expense selectedExpense;

        public MainViewModel()
        {
            selectedExpense = new Expense();
            databaseHelper = new DatabaseHelper();
            Refresh();
        }

        void Refresh()
        {
            expenses = new ObservableCollection<Expense>();
            List<Expense> expensesDB = databaseHelper.GetAllExpensesTracker();
            foreach (Expense expenseDB in expensesDB)
            {
                expenses.Add(expenseDB);
            }
        }

        [RelayCommand]
        async void Add()
        {
            await Shell.Current.GoToAsync(nameof(DetailPage));
            Refresh();

            /*
            expenses.Add(selectedExpense);
            selectedExpense = new Expense();
            */
        }

        [RelayCommand]
        void Delete(Expense expense)
        {
            if (expenses.Contains(expense))
            {
                //                expenses.Remove(expense);
                databaseHelper.DeleteExpense(expense);
                Refresh();
            }
        }

        [RelayCommand]
        async Task Tap(Expense expense)
        {
            await Shell.Current.GoToAsync(
                nameof(DetailPage),
                new Dictionary<string, object> {
                    { nameof(Expense), expense }
                }
            );
        }
    }
}