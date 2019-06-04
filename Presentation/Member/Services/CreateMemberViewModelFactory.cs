using System.Linq;
using System.Web.Mvc;
using Presentation.Member.Models;
using Application.Category.Queries.GetCategoriesList;
using Application.Member.Commands;

namespace Presentation
{
    public class CreateMemberViewModelFactory : ICreateMemberViewModelFactory
    {

        // Need a drop down for categories!!
        private readonly IGetCategoriesListQuery _categoriesListQuery;

        public CreateMemberViewModelFactory(
            IGetCategoriesListQuery categoriesListQuery)
        {
            _categoriesListQuery = categoriesListQuery;
        }

        public CreateMemberViewModel Create()
        {
            var categories = _categoriesListQuery.Execute();

            var viewModel = new CreateMemberViewModel();

            viewModel.Categories = categories
                .Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .ToList();

            viewModel.Member = new CreateMemberModel();

            return viewModel;
        }
    }
}