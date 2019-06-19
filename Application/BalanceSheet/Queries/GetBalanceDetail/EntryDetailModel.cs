using System;

namespace Application.BalanceSheet.Queries.GetBalanceDetail
{
    public class EntryDetailModel
    {
        public int Id { get; set; }
        
        public decimal Total { get; set; }
        public DateTime DateTime { get; set; }
        public string Name { get; set; }

        public int ChargeableId { get; set; }

        public bool Paid { get; set; }

        
    }
}
