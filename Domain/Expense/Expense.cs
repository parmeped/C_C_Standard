using Domain.Common;
using System;

namespace Domain
{
    [Serializable]
    public class Expense : IBalanceSheetEntry
    {
        public int Id { get; set; }

        public int balanceSheetId { get; set; }
        public DateTime DateTime { get; set; }
        public Chargeable Chargeable { get; set; }               

        public bool Paid { get; set; }

        public decimal Total
        {
            get { return Chargeable.Value * -1; }         
        }

    }
}
