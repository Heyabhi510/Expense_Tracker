using ExpenseTracker.Models;
using ExpenseTracker.ReqFields;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly DashboardContext _dbContext;
        public CategoryController(DashboardContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            if(ModelState.IsValid)
                 return Ok(await _dbContext.Categories.OrderBy(c => c.CategoryId).ToListAsync());

            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("{CategoryId:}")]
        public async Task<IActionResult> GetCategory([FromRoute] int CategoryId)
        {
            var category = await _dbContext.Categories.FindAsync(CategoryId);

            if (category == null)
            {
                return NotFound();
            }
            else
                return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategories(AddCategoryRequest addCategoryRequest)
        {
            var category = new Category()
            {
                Name = addCategoryRequest.Name,
                Limit = addCategoryRequest.Limit
            };

            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return Ok(category);
        }

        [HttpPut]
        [Route("{CategoryId:}")]
        public async Task<IActionResult> PutCategory([FromRoute] int CategoryId, UpdateCategoryRequest updateCategoryRequest)
        {
            var category = await _dbContext.Categories.FindAsync(CategoryId);

            if (category != null)
            {
                category.Name = updateCategoryRequest.Name;
                category.Limit = updateCategoryRequest.Limit;

                await _dbContext.SaveChangesAsync();

                return Ok(category);
            }
            else
                return NotFound();
        }

        [HttpDelete]
        [Route("{CategoryId:}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int CategoryId)
        {
            var category = await _dbContext.Categories.FindAsync(CategoryId);

            if (category != null)
            {
                _dbContext.Remove(category);
                await _dbContext.SaveChangesAsync();
                return Ok(category);
            }
            return NotFound();
        }
    }
}