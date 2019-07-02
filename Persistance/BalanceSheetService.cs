using Application.Interfaces;
using Application.BalanceSheet.Queries.GetBalanceDetail;
using System.Collections.Generic;
using System.Linq;

namespace Persistance
{
    public class BalanceSheetServices
        : IBalanceSheetService
    {           
        public void BalanceSave(int balanceSheetId)            
        {
            DatabaseService database = new DatabaseService();


            var balance = database.BalanceSheets
                .Find(balanceSheetId);

            var expenses = database.Expenses
                .Where(x => x.balanceSheetId == balance.Id)
                .Select(x => new EntryDetailModel()
                {
                    Total = x.Chargeable.Value * -1
                })
                .ToList();

            var payments = database.Payments
                .Where(x => x.balanceSheetId == balance.Id)
                .Select(x => new EntryDetailModel()
                {
                    Total = x.Total
                })
                .ToList();

            balance.Balance = GiveMeBalance(expenses, payments);

            database.Save();
        }

        private decimal GiveMeBalance(IEnumerable<EntryDetailModel> expenses, IEnumerable<EntryDetailModel> payments)
        {
            decimal totalAgainst = 0;
            decimal totalFavor = 0;
            if (expenses != null)
            {
                totalAgainst = expenses
                    .Sum(x => x.Total);
            }
            if (payments != null)
            {
                totalFavor = payments
                    .Sum(x => x.Total);
            }
            decimal total = 0;

            total = totalFavor > totalAgainst ? totalFavor + totalAgainst : totalAgainst + totalFavor;

            return total;
            ;
        }
    }
}
