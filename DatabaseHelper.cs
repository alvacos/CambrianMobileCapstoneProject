using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambrianMobileCapstoneProject
{
    // ExpenseTracker class
    [Table("expense")]
    public class Expense
    {
        public Expense() // Make the constructor public
        {
            Id = 0;
            Name = string.Empty;
            Category = string.Empty;
            Amount = 0.0;
            Date = DateTime.Now;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Category { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }

    public class DatabaseHelper
    {
        // Database name
        public const string DatabaseFilename = "expensesTracker.db";

        // Path to the SQLite database
        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        // SQLite connection
        private SQLiteConnection conn;

        public DatabaseHelper()
        {
            // Create the connection to the SQLite database
            conn = new SQLiteConnection($"Data Source={DatabasePath}");

            // Create the ExpensesTracker table
            conn.CreateTable<Expense>();
        }

        // Add a new expense tracker to the database
        public int AddNewExpense(Expense expense)
        {
            int result = conn.Insert(expense);
            return result;
        }

        // Get all expenses tracker from the database
        public List<Expense> GetAllExpensesTracker()
        {
            List<Expense> expenses = conn.Table<Expense>().ToList();
            return expenses;
        }

        // Update an expense tracker in the database
        public int UpdateExpense(Expense expense)
        {
            int result = conn.Update(expense); // Use Update instead of Insert
            return result;
        }

        // Delete an expense tracker from the database
        public int DeleteExpense(Expense expense)
        {
            int result = conn.Delete(expense);
            return result;
        }
    }
}
