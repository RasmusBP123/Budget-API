using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fællesbudget.Models;
using Fællesbudget.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fællesbudget.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : Controller
    {
        private readonly IBudgetRepository _repository;

        public ExpenseController(IBudgetRepository repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        public IActionResult GetAllExpenses()
        {
            return Ok(_repository.GetAllExpenses());
        }

        [HttpGet("{id}")]
        public IActionResult GetExpense(int id)
        {
            return Ok(_repository.GetExpense(id));
        }

        [HttpPost]
        public IActionResult CreateExpense([FromBody] Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _repository.CreateExpense(expense);

            _repository.saveChanges();

            return CreatedAtRoute("GetExpense", new {expense.id}, expense);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateExpense(int id, [FromBody] Expense expense)
        {
            var updatedExpense = _repository.GetExpense(id);
            _repository.UpdateExpense(updatedExpense);

            _repository.saveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExpense(int id)
        {
            _repository.DeleteExpense(id);
            _repository.saveChanges();
            return NoContent();
        }
    }
}