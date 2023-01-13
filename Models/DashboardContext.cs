using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Models
{
    public class DashboardContext : DbContext
    {
        public DashboardContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<TotalExpLimit> TotalExpense { get; set; }
    }
}
