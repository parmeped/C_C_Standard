using System;

namespace Application.BalanceSheet.Commands.Expense.Factory
{
    public interface IExpenseFactory
    {
        Domain.Expense Create(int BalanceSheetId, Domain.Chargeable Chargeable);
    }
}
