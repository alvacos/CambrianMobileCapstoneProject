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
            try
            {
                // Log the database path
                Console.WriteLine($"Database Path: {DatabasePath}");

                // Initialize the connection
                conn = new SQLiteConnection(DatabasePath);

                // Create the table
                conn.CreateTable<Expense>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database initialization failed: {ex.Message}");
                throw; // Rethrow the exception for debugging purposes
            }

            //// Create the connection to the SQLite database
            //conn = new SQLiteConnection($"Data Source={DatabasePath}");

            //// Create the ExpensesTracker table
            //conn.CreateTable<Expense>();
        }

        // Add a new expense tracker to the database
        public int AddNewExpense(Expense expense)
        {
            try
            {
                return conn.Insert(expense);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AddNewExpense error: {ex.Message}");
                return -1; // Indicate failure
            }
            //int result = conn.Insert(expense);
            //return result;
        }

        // Get all expenses tracker from the database
        public List<Expense> GetAllExpensesTracker()
        {
            try
            {
                return conn.Table<Expense>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAllExpensesTracker error: {ex.Message}");
                return new List<Expense>(); // Return empty list on failure
            }
            //List<Expense> expenses = conn.Table<Expense>().ToList();
            //return expenses;
        }

        // Update an expense tracker in the database
        public int UpdateExpense(Expense expense)
        {
            try
            {
                return conn.Update(expense);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateExpense error: {ex.Message}");
                return -1; // Indicate failure
            }
            //int result = conn.Update(expense); // Use Update instead of Insert
            //return result;
        }

        // Delete an expense tracker from the database
        public int DeleteExpense(Expense expense)
        {
            try
            {
                return conn.Delete(expense);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteExpense error: {ex.Message}");
                return -1; // Indicate failure
            }
            //int result = conn.Delete(expense);
            //return result;
        }
    }
}
