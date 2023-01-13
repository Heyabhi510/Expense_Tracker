using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        [Required]
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public int CategoryId { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public int Amount { get; set; }
        public string Date { get; set; } = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
    }
}
