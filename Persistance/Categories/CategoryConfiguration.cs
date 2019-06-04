using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Persistance
{
    class CategoryConfiguration 
        : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Name)
                .IsRequired();

            HasRequired(x => x.Chargeable);
        }
    }
}
