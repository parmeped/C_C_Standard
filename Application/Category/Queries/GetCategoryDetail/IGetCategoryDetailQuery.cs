using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Category.Queries.GetCategoryDetail
{
    public interface IGetCategoryDetailQuery
    {
        CategoryDetailModel Execute(int Id);

    }
}
