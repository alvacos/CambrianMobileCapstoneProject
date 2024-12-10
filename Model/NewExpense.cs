using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambrianMobileCapstoneProject.Model
{
    public class NewExpense
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public double Amount { get; set; } = 0.0;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
