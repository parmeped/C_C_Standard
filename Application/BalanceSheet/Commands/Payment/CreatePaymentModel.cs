using System.Collections.Generic;

namespace Application.BalanceSheet.Commands.Payment
{
    public class CreatePaymentModel
    {
        public int balanceSheetId { get; set; }       
        public List<ExpenseModel> Expenses { get; set; }
    }
}
