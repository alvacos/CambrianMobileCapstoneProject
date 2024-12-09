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
        private readonly DatabaseHelper _databaseHelper;

        public MainPageViewModel()
        {
            _databaseHelper = new DatabaseHelper();
            LoadExpenses();

            // Initialize commands
            AddExpenseCommand = new Command(OnAddExpense);
            EditExpenseCommand = new Command(OnEditExpense, () => IsExpenseSelected);
            DeleteExpenseCommand = new Command(OnDeleteExpense, () => IsExpenseSelected);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Auto-implemented properties
        public Expense SelectedExpense { get; set; }
        public List<Expense> Expenses { get; set; } = new List<Expense>();
        public ICommand AddExpenseCommand { get; }
        public ICommand EditExpenseCommand { get; }
        public ICommand DeleteExpenseCommand { get; }

        // Determines if an expense is selected
        public bool IsExpenseSelected => SelectedExpense != null;

        // Method to load expenses from the database
        private void LoadExpenses()
        {
            Expenses = _databaseHelper.GetAllExpensesTracker();
            OnPropertyChanged(nameof(Expenses));
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
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

