using System;
using System.Collections.Generic;

namespace Application.BalanceSheet.Commands.Payment.Factory
{
    public interface IPaymentFactory
    {
        Domain.Payment Create(int BalanceSheetId, List<Domain.Expense> Expenses);
    }
}
