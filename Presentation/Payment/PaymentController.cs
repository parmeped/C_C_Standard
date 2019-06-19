using Persistance;
using System.Web.Mvc;
using Presentation.Payment.Models;
using Application.BalanceSheet.Commands.Payment;
using Application.BalanceSheet.Commands.Payment.Factory;
using Application.BalanceSheet.Queries.GetBalanceUnpaid;
using System.Collections.Generic;

namespace Presentation.BalanceSheet
{
    [RoutePrefix("payments")]
    public class PaymentController : Controller
    {
                
        private readonly ICreatePaymentViewModelFactory _factory;
        private readonly ICreatePaymentCommand _createPaymentCommand;

        public PaymentController()
        {
            PaymentFactory paymentFactory = new PaymentFactory();
            GetBalanceUnpaidQuery unpaidsListQuery = new GetBalanceUnpaidQuery(new DatabaseService());            
            CreatePaymentViewModelFactory factory = new CreatePaymentViewModelFactory(unpaidsListQuery);
            CreatePaymentCommand createPaymentCommand = new CreatePaymentCommand(new DatabaseService(), paymentFactory);
        
            _factory = factory;
            _createPaymentCommand = createPaymentCommand;
        }

        [Route("{id:int}")]
        public ViewResult CreatePayment(int id)
        {
            var payment = _factory.Create(id);

            return View("CreatePayment", payment);
        }


        [Route("{id:int}")]
        [HttpPost]
        public RedirectToRouteResult Create(CreatePaymentViewModel viewModel)
        {
            CreatePaymentModel model = new CreatePaymentModel();
            model.balanceSheetId = viewModel.balanceSheetId;
            model.Expenses = new List<ExpenseModel>();

            for (int i = 0; i < viewModel.Expenses.Count; i++)
            {
                var item = viewModel.Expenses[i];
                if (item.Paid)
                {
                    ExpenseModel expenseModel = new ExpenseModel() { ExpenseId = item.Id, Paid = item.Paid, ChargeableId = item.ChargeableId };
                    model.Expenses.Add(expenseModel);
                }
            }


            _createPaymentCommand.Execute(model);

            return RedirectToAction("Detail", "balanceSheet", model.balanceSheetId);
        }
    }
}	
