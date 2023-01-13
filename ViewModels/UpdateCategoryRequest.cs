using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.ReqFields
{
    public class UpdateCategoryRequest
    {
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public int Limit { get; set; }
    }
}
