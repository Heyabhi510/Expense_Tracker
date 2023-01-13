using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class TotalExpLimit
    {
        [Key]
        public int ExpLimitId { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
    }
}
