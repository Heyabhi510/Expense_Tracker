using ExpenseTracker.Models;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.ReqFields
{
    public class AddCategoryRequest
    {
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public int Limit { get; set; }
    }
    //public virtual List<Expense> Expenses { get; set; }
}
