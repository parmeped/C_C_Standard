using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    [Serializable]
    public class BalanceSheet : IEntity
    {
        public int Id { get; set; }        
        public List<Expense> Expenses { get; set; }
        public List<Payment> Payments { get; set; }

        public decimal Balance { get; set; }

        public Member Member { get; set; }
    }
}
