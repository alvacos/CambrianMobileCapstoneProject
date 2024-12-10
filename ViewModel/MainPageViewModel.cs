using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CambrianMobileCapstoneProject.Model; // Add this using statement to access the ExpenseManager class

namespace CambrianMobileCapstoneProject.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseHelper _databaseHelper;
        private readonly ExpenseManager _expenseManager;

        public ICommand NavigateToAddExpenseCommand { get; }

        public MainPageViewModel()
        {
            _databaseHelper = new DatabaseHelper();
            _expenseManager = new ExpenseManager();
            LoadExpenses();

            // Initialize commands
            AddExpenseCommand = new Command(OnAddExpense);
            EditExpenseCommand = new Command(OnEditExpense, () => IsExpenseSelected);
            DeleteExpenseCommand = new Command(OnDeleteExpense, () => IsExpenseSelected);

            NavigateToAddExpenseCommand = new Command(NavigateToAddExpense);
        }

        private async void NavigateToAddExpense()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddExpensePage());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Auto-implemented properties
        public Expense SelectedExpense{
            get => _expenseManager.SelectedExpense;
            set
            {
                _expenseManager.SelectedExpense = value;
                OnPropertyChanged();
            }
        }
        public List<Expense> Expenses
        {
            get => _expenseManager.Expenses;
            set
            {
                _expenseManager.Expenses = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddExpenseCommand { get; }
        public ICommand EditExpenseCommand { get; }
        public ICommand DeleteExpenseCommand { get; }

        // Determines if an expense is selected
        public bool IsExpenseSelected => SelectedExpense != null;

        // Method to load expenses from the database
        private void LoadExpenses()
        {
            Expenses = _databaseHelper.GetAllExpensesTracker();           
        }

        // Add expense method
        private void OnAddExpense()
        {
            var newExpense = new Expense
            {
                Name = "New Expense",
                Category = "General",
                Amount = 0.0,
                Date = DateTime.Now
            };

            if (_databaseHelper.AddNewExpense(newExpense) > 0)
            {
                LoadExpenses(); // Refresh the list
            }
        }

        // Edit expense method
        private void OnEditExpense()
        {
            if (SelectedExpense == null) return;

            // Example change for editing
            SelectedExpense.Name = "Updated Expense"; // Replace with actual input logic
            _databaseHelper.UpdateExpense(SelectedExpense);
            LoadExpenses(); // Refresh the list
        }

        // Delete expense method
        private void OnDeleteExpense()
        {
            if (SelectedExpense == null) return;

            _databaseHelper.DeleteExpense(SelectedExpense);
            SelectedExpense = null; // Clear selection
            LoadExpenses(); // Refresh the list
        }

        // Notify property change
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

