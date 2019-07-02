using Domain;
using System.Data.Entity.ModelConfiguration;

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
