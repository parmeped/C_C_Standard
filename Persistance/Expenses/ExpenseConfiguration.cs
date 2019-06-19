using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Persistence
{
    public class ExpenseConfiguration
        : EntityTypeConfiguration<Expense>
    {
        public ExpenseConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.DateTime);

            HasRequired(x => x.Chargeable);

            Property(x => x.Paid);
        }
    }
}