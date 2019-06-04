using Domain;
using System.Data.Entity;

namespace Application
{
    public interface IDatabaseService
    {
        IDbSet<Domain.Member> Members { get; set; }
        IDbSet<Domain.Category> Categories { get; set; }        
        IDbSet<Domain.Chargeable> Chargeables { get; set; }
        IDbSet<Domain.BalanceSheet> BalanceSheets { get; set; }
        IDbSet<Domain.Expense> Expenses { get; set; }
        IDbSet<Domain.Payment> Payments { get; set; }

        void Save();
    }
}
