using ExpenseTracker.Models;
using ExpenseTracker.ReqFields;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : Controller
    {
        private readonly DashboardContext _dbContext;
        public ExpenseController(DashboardContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetExpenses()
        {
            if (ModelState.IsValid)
                return Ok(await _dbContext.Expenses.OrderBy(e => e.ExpenseId).ToListAsync());

            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("Category/{CategoryId:}")]
        public async Task<IActionResult> GetExpensesByCatId(int CategoryId)
        {
            if (ModelState.IsValid)
                return Ok(await _dbContext.Expenses.Where(e=> e.CategoryId == CategoryId).OrderBy(e => e.ExpenseId).ToListAsync());

            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("{ExpenseId:}")]
        public async Task<IActionResult> GetExpense([FromRoute] int ExpenseId)
        {
            var expense = await _dbContext.Expenses.FindAsync(ExpenseId);

            if (expense == null)
            {
                return NotFound();
            }
            else
                return Ok(expense);
        }

        [HttpPost]
        public async Task<IActionResult> PostExpenses(AddExpenseRequest addExpenseRequest)
        {
            var expense = new Expense()
            {
                Title = addExpenseRequest.Title,
                Description = addExpenseRequest.Description,
                CategoryId = addExpenseRequest.CategoryId,
                Amount = addExpenseRequest.Amount,
                Date = addExpenseRequest.Date
            };

            await _dbContext.Expenses.AddAsync(expense);
            await _dbContext.SaveChangesAsync();

            return await GetExpensesByCatId(expense.CategoryId);
        }

        [HttpPut]
        [Route("{ExpenseId:}")]
        public async Task<IActionResult> PutExpense([FromRoute] int ExpenseId, UpdateExpenseRequest updateExpenseRequest)
        {
            var expense = await _dbContext.Expenses.FindAsync(ExpenseId);

            if (expense != null)
            {
                expense.Title = updateExpenseRequest.Title;
                expense.Description = updateExpenseRequest.Description;
                expense.CategoryId = updateExpenseRequest.CategoryId;
                expense.Amount = updateExpenseRequest.Amount;
                expense.Date = updateExpenseRequest.Date;

                await _dbContext.SaveChangesAsync();

                return Ok(expense);
            }
            else
                return NotFound();
        }

        [HttpDelete]
        [Route("{ExpenseId:}")]
        public async Task<IActionResult> DeleteExpense([FromRoute] int ExpenseId)
        {
            var expense = await _dbContext.Expenses.FindAsync(ExpenseId);

            if (expense != null)
            {
                _dbContext.Remove(expense);
                await _dbContext.SaveChangesAsync();
                return Ok(expense);
            }
            return NotFound();
        }
    }
}