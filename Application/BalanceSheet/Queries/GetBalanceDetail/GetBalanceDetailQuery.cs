using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.BalanceSheet.Queries.GetBalanceDetail
{
    public class GetBalanceDetailQuery 
        :  IGetBalanceDetailQuery
    {
        private readonly IDatabaseService _database;

        public GetBalanceDetailQuery(IDatabaseService database)
        {
            _database = database;
        }

        public BalanceDetailModel Execute(int balanceId)
        {
            var balance = _database.BalanceSheets
                .Where(x => x.Id == balanceId)
                .Select(x => new BalanceDetailModel()
                {
                    Id = x.Id,
                    Total = x.Balance                    
                })
                .Single();

            var expenses = _database.Expenses
                .Where(x => x.balanceSheetId == balance.Id)
                .Select(x => new EntryDetailModel()
                {
                    Id = x.Id,
                    Total = x.Chargeable.Value * -1,
                    Paid = x.Paid,
                    DateTime = x.DateTime
                })
                .ToList();

            var payments = _database.Payments
                .Where(x => x.balanceSheetId == balance.Id)
                .Select(x => new EntryDetailModel()
                {
                    Id = x.Id,
                    DateTime = x.DateTime,
                    Total = x.Total
                })
                .ToList();            
            
            balance.Entries = new List<EntryDetailModel>();
            
            foreach (EntryDetailModel ex in expenses)
            {
                balance.Entries.Add(ex);
            }
            foreach (EntryDetailModel pay in payments)
            {
                balance.Entries.Add(pay);
            }           

            return balance;
        }
    }
}
