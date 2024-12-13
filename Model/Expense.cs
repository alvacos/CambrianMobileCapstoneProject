using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambrianMobileCapstoneProject.Model
{
    [Table("expense")]
    public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Name { get; set; }

        [MaxLength(10)]
        public string Category { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        // Default constructor public
        public Expense()
        {
            Id = 0;
            Name = string.Empty;
            Category = string.Empty;
            Amount = 0.0;
            Date = DateTime.Now;
        }

        public Expense(int id, string name, string category, double amount, DateTime date)
        {
            Id = id;
            Name = name;
            Category = category;
            Amount = amount;
            Date = date;
        }
    }
}
