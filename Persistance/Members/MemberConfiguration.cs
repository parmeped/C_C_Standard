using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

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

            HasRequired(x => x.BalanceSheet);
        }
    }
}