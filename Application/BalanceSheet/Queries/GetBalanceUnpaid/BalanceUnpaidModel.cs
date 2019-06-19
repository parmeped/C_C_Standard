using Application.BalanceSheet.Queries.GetBalanceDetail;
using System.Collections.Generic;


namespace Application.BalanceSheet.Queries.GetBalanceUnpaid
{
    public class BalanceUnpaidModel
    {
        public int Id { get; set; }        
        public List<EntryDetailModel> Entries { get; set; }        
        
    }
}
