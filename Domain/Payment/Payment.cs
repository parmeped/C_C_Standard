using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    [Serializable]
    public class Payment : IBalanceSheetEntry
    {
        public int Id { get; set; }

        public int balanceSheetId { get; set; }

        public DateTime DateTime { get; set; }
        public List<Expense> ExpensesPaid { get; set; }

        public decimal Total { get; set; }        

        public void calculateTotal()
        {
            decimal total = 0;
            if (ExpensesPaid.Any())
            {
                foreach (Expense ex in ExpensesPaid)
                {
                    total += ex.Total;
                }                
            }
            Total = total * -1;
        }
    }
}
