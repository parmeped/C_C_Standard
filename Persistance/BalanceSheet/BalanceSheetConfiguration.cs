using System.Data.Entity.ModelConfiguration;

namespace Persistance
{
    class BalanceSheetConfiguration
        : EntityTypeConfiguration<Domain.BalanceSheet>
    {
        public BalanceSheetConfiguration()
        {
            HasKey(x => x.Id);            

            HasMany(x => x.Payments);

            HasMany(x => x.Expenses);

            Property(x => x.Balance);
        }
    }
}
