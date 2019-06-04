using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Persistence
{
    public class PaymentConfiguration
        : EntityTypeConfiguration<Payment>
    {
        public PaymentConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.DateTime);

            Property(x => x.Total);

            HasMany(x => x.ExpensesPaid);
        }
    }
}