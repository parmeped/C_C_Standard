using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.BalanceSheet.Queries.GetBalanceList
{
    public class GetBalanceListQuery : IGetBalanceListQuery
    {
        private readonly IDatabaseService _database;

        public GetBalanceListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<BalanceListItemModel> Execute()
        {
            var balanceSheets = _database.BalanceSheets
                .Select(x => new BalanceListItemModel()
                {
                    Id = x.Id,                    
                    Total = x.Balance                   
                });

            return balanceSheets.ToList();
        }

    }
}
