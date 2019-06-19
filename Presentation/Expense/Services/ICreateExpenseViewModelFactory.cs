using Presentation.Expense.Models;

namespace Presentation
{
    public interface ICreateExpenseViewModelFactory
    {
        CreateExpenseViewModel Create(int BalanceSheetId);
    }
}