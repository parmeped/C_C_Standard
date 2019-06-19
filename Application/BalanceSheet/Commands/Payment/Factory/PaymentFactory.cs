using System;
using System.Collections.Generic;

namespace Application.BalanceSheet.Commands.Payment.Factory
{
    public class PaymentFactory : IPaymentFactory
    {
        public Domain.Payment Create(int BalanceSheetId, List<Domain.Expense> Expenses)
        {
            Domain.Payment payment = new Domain.Payment()
            {
                balanceSheetId = BalanceSheetId,
                ExpensesPaid = Expenses
            };

            payment.DateTime = DateTime.Now;
            payment.calculateTotal();

            return payment;
        }
    }
}
