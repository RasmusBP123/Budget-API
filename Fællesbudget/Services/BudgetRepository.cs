using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fællesbudget.Data;
using Fællesbudget.Models;
using Microsoft.EntityFrameworkCore;

namespace Fællesbudget.Services
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly DataContext _context;

        public BudgetRepository(DataContext context)
        {
            _context = context;
        }

        public void CreateExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
        }

        public void DeleteExpense(int id)
        {
            var expense = GetExpense(id);
            _context.Expenses.Remove(expense);
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            return _context.Expenses.ToList();
        }

        public Expense GetExpense(int id)
        {
            return _context.Expenses.FirstOrDefault(x => x.id == id);
        }

        public void saveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateExpense(Expense expense)
        {
            _context.Entry(expense).State = EntityState.Modified;
        }
    }
}
