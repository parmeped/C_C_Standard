using Application.Chargeable.Queries.GetChargeablesList;
using Presentation.Expense.Models;
using System.Linq;
using System.Web.Mvc;

namespace Presentation
{
    public class CreateExpenseViewModelFactory : ICreateExpenseViewModelFactory
    {

        
        private readonly IGetChargeablesListQuery _chargeablesListQuery;        

        public CreateExpenseViewModelFactory(
            IGetChargeablesListQuery chargeablesListQuery)
        {
            _chargeablesListQuery = chargeablesListQuery;            
        }

        public CreateExpenseViewModel Create(int balanceSheetId)
        {
            var chargeables = _chargeablesListQuery.Execute();            

            var viewModel = new CreateExpenseViewModel();           

            viewModel.Chargeables = chargeables
                .Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .ToList();           

            viewModel.balanceSheetId = balanceSheetId;

            return viewModel;
        }
    }
}