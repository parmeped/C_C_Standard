using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BalanceSheet.Commands.Expense.Factory
{
    public class ExpenseFactory : IExpenseFactory
    {
        public Domain.Expense Create(int BalanceSheetId, Domain.Chargeable Chargeable)
        {
            Domain.Expense expense = new Domain.Expense
            {
                balanceSheetId = BalanceSheetId,                
                Chargeable = Chargeable                
            };

            expense.DateTime = DateTime.Now;

            return expense;
        }
    }
}
