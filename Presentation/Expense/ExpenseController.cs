using Persistance;
using System.Web.Mvc;
using Application.BalanceSheet.Queries.GetBalanceList;
using Application.BalanceSheet.Queries.GetBalanceDetail;
using Application.Chargeable.Queries.GetChargeablesList;
using Presentation.Expense.Models;
using Application.BalanceSheet.Commands.Expense;
using Application.BalanceSheet.Commands.Expense.Factory;

namespace Presentation.BalanceSheet
{
    [RoutePrefix("expenses")]
    public class ExpenseController : Controller
    {

        private readonly IGetBalanceListQuery _balanceListQuery;
        private readonly IGetBalanceDetailQuery _balanceDetailQuery;
        private readonly ICreateExpenseViewModelFactory _factory;
        private readonly ICreateExpenseCommand _createExpenseCommand;

        public ExpenseController()
        {
            ExpenseFactory expenseFactory = new ExpenseFactory();
            GetChargeablesListQuery chargeablesListQuery = new GetChargeablesListQuery(new DatabaseService());
            GetBalanceListQuery balanceListQuery = new GetBalanceListQuery(new DatabaseService());
            GetBalanceDetailQuery balanceDetailQuery = new GetBalanceDetailQuery(new DatabaseService());
            CreateExpenseViewModelFactory factory = new CreateExpenseViewModelFactory(chargeablesListQuery);
            CreateExpenseCommand createExpenseCommand = new CreateExpenseCommand(new DatabaseService(), expenseFactory);

            _balanceListQuery = balanceListQuery;
            _balanceDetailQuery = balanceDetailQuery;
            _factory = factory;
            _createExpenseCommand = createExpenseCommand;
        }

        [Route("{id:int}")]
        public ViewResult CreateExpense(int id)
        {
            var expense = _factory.Create(id);

            return View("CreateExpense", expense);
        }


        [Route("{id:int}")]
        [HttpPost]
        public RedirectToRouteResult Create(CreateExpenseViewModel viewModel)
        {
            CreateExpenseModel model = new CreateExpenseModel();
            model.balanceSheetId = viewModel.balanceSheetId;
            model.chargeableId = viewModel.chargeableId;

            _createExpenseCommand.Execute(model);

            return RedirectToAction("Detail", "balanceSheet", model.balanceSheetId);
        }
    }
}