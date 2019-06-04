using Domain;

namespace Application.Category.Queries.GetCategoryDetail
{
    public class CategoryDetailModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Domain.Chargeable Chargeable { get; set; }
        
    }
}
