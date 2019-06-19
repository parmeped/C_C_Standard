using Application.BalanceSheet.Queries.GetBalanceDetail;
using System.Collections.Generic;
using System.Linq;

namespace Application.BalanceSheet.Queries.GetBalanceUnpaid
{
    public class GetBalanceUnpaidQuery
        : IGetBalanceUnpaidQuery
    {
        private readonly IDatabaseService _database;

        public GetBalanceUnpaidQuery(IDatabaseService database)
        {
            _database = database;
        }

        public BalanceUnpaidModel Execute(int balanceId)
        {


            var balance = _database.BalanceSheets
                .Where(x => x.Id == balanceId)                
                .Select(x => new BalanceUnpaidModel()
                {
                    Id = x.Id
                })
                .Single();

            var expenses = _database.Expenses
                .Where(x => x.balanceSheetId == balance.Id)                
                .Where(x => x.Paid == false)
                .Select(x => new EntryDetailModel()
                {
                    Id = x.Id,
                    Name = x.Chargeable.Name,
                    ChargeableId = x.Chargeable.Id,
                    Total = x.Chargeable.Value * -1,
                    DateTime = x.DateTime
                })
                .ToList();
                        
            balance.Entries = new List<EntryDetailModel>();
            
            foreach (EntryDetailModel ex in expenses)
            {
                balance.Entries.Add(ex);
            }            

            return balance;
        }
    }
}
