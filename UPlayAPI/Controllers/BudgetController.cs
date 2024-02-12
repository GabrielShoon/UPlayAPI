using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UPlayAPI.Models;

namespace UPlayAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BudgetController : ControllerBase
    {
        private readonly MyDbContext _context;
        public BudgetController(MyDbContext context)
        {
            _context = context;
        }

        private int GetUserId()
        {
            return Convert.ToInt32(User.Claims
            .Where(c => c.Type == ClaimTypes.NameIdentifier)
            .Select(c => c.Value).SingleOrDefault());
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IQueryable<UserBudget> result = _context.UserBudget.Include(b => b.User);

            var list = result.ToList();

            var data = list.Select(t => new
            {
                t.Id,
                t.Budget,
                t.CreatedAt,
                t.UpdatedAt,
                t.UserId,
                User = new
                {
                    t.User?.Name
                }
            });
            return Ok(data);
        }

        [HttpPost, Authorize]
        public IActionResult AddBudget(UserBudget budget)
        {
            int userId = GetUserId();

            // Check if the user has already set a budget
            var existingBudget = _context.UserBudget.FirstOrDefault(b => b.UserId == userId);

            if (existingBudget != null)
            {
                // User has already set a budget, update it
                existingBudget.Budget = budget.Budget;
                existingBudget.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return Ok(existingBudget);
            }

            // User has not set a budget before, add a new budget
            var now = DateTime.Now;
            var myBudget = new UserBudget()
            {
                Budget = budget.Budget,
                CreatedAt = now,
                UpdatedAt = now,
                UserId = userId
            };
            _context.UserBudget.Add(myBudget);
            _context.SaveChanges();
            return Ok(myBudget);
        }
    }
}
