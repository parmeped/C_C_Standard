using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Persistence
{
    public class MemberConfiguration
        : EntityTypeConfiguration<Member>
    {
        public MemberConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            HasRequired(x => x.Category);
                
            Property(x => x.BirthDate);

            HasOptional(f => f.BalanceSheet)
                .WithRequired(x => x.Member);            
        }
    }
}