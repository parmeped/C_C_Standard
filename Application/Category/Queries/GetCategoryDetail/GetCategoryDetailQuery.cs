using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Category.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQuery 
        :  IGetCategoryDetailQuery
    {
        private readonly IDatabaseService _database;

        public GetCategoryDetailQuery(IDatabaseService database)
        {
            _database = database;
        }

        public CategoryDetailModel Execute(int categoryId)
        {
            var category = _database.Categories
                .Where(x => x.Id == categoryId)
                .Select(x => new CategoryDetailModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Chargeable = x.Chargeable
                })
                .Single();

            return category;
        }
    }
}
