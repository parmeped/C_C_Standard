using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BalanceSheet : IEntity
    {
        public int Id { get; set; }        
        public List<Expense> Expenses { get; set; }
        public List<Payment> Payments { get; set; }

        public decimal Balance { get; set; }
        

        public void netBalance()
        {
            decimal totalAgainst = 0;
            decimal totalFavor = 0;

            if (Expenses != null && Payments != null)
            {
                foreach(Expense ex in Expenses)
                {
                    totalAgainst += ex.Chargeable.Value;                
                }
                foreach (Payment pay in Payments)
                {
                    totalFavor += pay.Total;
                }
            }
            Balance = totalFavor - totalAgainst;
        }
    }
}
