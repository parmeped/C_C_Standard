using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BalanceSheet.Queries.GetBalanceDetail
{
    public class EntryDetailModel
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime DateTime { get; set; }
        
    }
}
