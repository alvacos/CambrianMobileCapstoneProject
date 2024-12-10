using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CambrianMobileCapstoneProject.ViewModel;

namespace CambrianMobileCapstoneProject.Model
{
    public class ExpenseManager
    {
        public Expense SelectedExpense { get; set; }
        public List<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
