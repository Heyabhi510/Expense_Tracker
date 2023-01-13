using ExpenseTracker.Models;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.ReqFields
{
    public class AddExpenseRequest
    {
        [Required]
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int Amount { get; set; }
        public string Date { get; set; } = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
    }
}
