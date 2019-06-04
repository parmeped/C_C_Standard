using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Persistance
{
    class ChargeableConfiguration
        : EntityTypeConfiguration<Chargeable>
    {
        public ChargeableConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Value)
                .IsRequired()
                .HasPrecision(10, 2);

            Property(x => x.Active)
                .IsRequired();
        }
    }
}
