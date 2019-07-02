using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Persistence
{
    public class ExpenseConfiguration
        : EntityTypeConfiguration<Expense>
    {
        public ExpenseConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.DateTime);

            Property(x => x.balanceSheetId);

            HasRequired(x => x.Chargeable);

            Property(x => x.Paid);
        }
    }
}