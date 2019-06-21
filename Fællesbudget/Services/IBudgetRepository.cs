using Fællesbudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fællesbudget.Services
{
    public interface IBudgetRepository
    {
        IEnumerable<Expense> GetAllExpenses();
        Expense GetExpense(int id);
        void CreateExpense(Expense expense);
        void UpdateExpense(Expense expense);
        void DeleteExpense(int id);
        void saveChanges();
    }
}
