using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Category.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IGetCategoriesListQuery 
    {
        private readonly IDatabaseService _database;

        public GetCategoriesListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<CategoriesListItemModel> Execute()
        {
            var categories = _database.Categories
                .Select(x => new CategoriesListItemModel()
                {
                    Id = x.Id,
                    Name = x.Name
                });

            return categories.ToList();
        }
    }
}
