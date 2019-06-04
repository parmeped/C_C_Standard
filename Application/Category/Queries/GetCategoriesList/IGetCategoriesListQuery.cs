using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Category.Queries.GetCategoriesList
{
    public interface IGetCategoriesListQuery
    {
        List<CategoriesListItemModel> Execute();
    }
}
