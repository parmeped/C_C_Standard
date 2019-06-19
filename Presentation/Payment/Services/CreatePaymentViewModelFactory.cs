using Application.BalanceSheet.Queries.GetBalanceUnpaid;
using Application.Chargeable.Queries.GetChargeablesList;
using Presentation.Payment.Models;

namespace Presentation
{
    public class CreatePaymentViewModelFactory : ICreatePaymentViewModelFactory
    {

        
        private readonly IGetBalanceUnpaidQuery _unpaidsListQuery;        

        public CreatePaymentViewModelFactory(
            IGetBalanceUnpaidQuery unpaidsListQuery)
        {
            _unpaidsListQuery = unpaidsListQuery;            
        }

        public CreatePaymentViewModel Create(int balanceSheetId)
        {
            var unpaids = _unpaidsListQuery.Execute(balanceSheetId);

            var viewModel = new CreatePaymentViewModel();           

            viewModel.balanceSheetId = balanceSheetId;
            viewModel.Expenses = unpaids.Entries;

            return viewModel;
        }
    }
}