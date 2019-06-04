using Domain;
using Domain.Common;
using System.Collections.Generic;

namespace Application.BalanceSheet.Queries.GetBalanceDetail
{
    public class BalanceDetailModel
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public List<EntryDetailModel> Entries { get; set; }        
        
    }
}
