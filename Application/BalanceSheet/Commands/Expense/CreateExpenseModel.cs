using System;

namespace Application.BalanceSheet.Commands.Expense
{
    public class CreateExpenseModel
    {
        public int balanceSheetId { get; set; }       

        public int chargeableId { get; set; }

        public Domain.Chargeable Chargeable { get; set; }
    }
}
