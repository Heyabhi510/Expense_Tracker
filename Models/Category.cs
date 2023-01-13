using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public int Limit { get; set; }
        public virtual List<Expense> Expenses { get; set; }
    }
}