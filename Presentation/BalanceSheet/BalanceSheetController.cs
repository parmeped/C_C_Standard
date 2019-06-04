using Persistance;
using System.Web.Mvc;
using Application.BalanceSheet.Queries.GetBalanceList;
using Application.BalanceSheet.Queries.GetBalanceDetail;

namespace Presentation.BalanceSheet
{
    [RoutePrefix("balanceSheets")]
    public class BalanceSheetController : Controller
    {

        private readonly IGetBalanceListQuery _balanceListQuery;
        private readonly IGetBalanceDetailQuery _balanceDetailQuery;

        public BalanceSheetController()
        {
            GetBalanceListQuery balanceListQuery = new GetBalanceListQuery(new DatabaseService());
            GetBalanceDetailQuery balanceDetailQuery = new GetBalanceDetailQuery(new DatabaseService());

            _balanceListQuery = balanceListQuery;
            _balanceDetailQuery = balanceDetailQuery;
        }

        [Route("{id:int}")]
        public ViewResult Detail(int id)
        {
            var balanceSheet = _balanceDetailQuery.Execute(id);

            return View(balanceSheet);
        }

    }
}