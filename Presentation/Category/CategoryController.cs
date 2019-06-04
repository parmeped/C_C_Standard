using Application.Category.Queries.GetCategoriesList;
using Application.Category.Queries.GetCategoryDetail;
using Persistance;
using System.Web.Mvc;

namespace Presentation.Category
{
    [RoutePrefix("categories")]
    public class CategoryController : Controller
    {
        private readonly IGetCategoriesListQuery _categoriesListQuery;
        private readonly IGetCategoryDetailQuery _categoryDetailQuery;

        public CategoryController()
        {
            GetCategoriesListQuery categoriesListQuery = new GetCategoriesListQuery(new DatabaseService());
            GetCategoryDetailQuery categoryDetailQuery = new GetCategoryDetailQuery(new DatabaseService());

            _categoriesListQuery = categoriesListQuery;
            _categoryDetailQuery = categoryDetailQuery;            
        }


        [Route("")]
        public ViewResult Index()
        {
            var categories = _categoriesListQuery.Execute();

            return View(categories);
        }

        [Route("{id:int}")]
        public ViewResult Detail(int id)
        {
            var category = _categoryDetailQuery.Execute(id);

            return View(category);
        }
    }
}