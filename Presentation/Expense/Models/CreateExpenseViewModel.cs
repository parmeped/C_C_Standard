using Application.BalanceSheet.Commands.Expense;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Presentation.Expense.Models
{
    public class CreateExpenseViewModel
    {
        public IEnumerable<SelectListItem> Chargeables { get; set; }

        public int balanceSheetId { get; set; }       
        
        public int chargeableId { get; set; }

        public CreateExpenseModel Expense { get; set; }
        
    }
}