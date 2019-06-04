using Application.Chargeable.Queries.GetChargeableDetail;
using Application.Chargeable.Queries.GetChargeablesList;
using Persistance;
using System.Web.Mvc;

namespace Presentation.Chargeable
{
    [RoutePrefix("chargeables")]
    public class ChargeableController : Controller
    {
        private readonly IGetChargeablesListQuery _chargeablesListQuery;
        private readonly IGetChargeableDetailQuery _chargeableDetailQuery;

        public ChargeableController()
        {
            GetChargeablesListQuery chargeablesListQuery = new GetChargeablesListQuery(new DatabaseService());
            GetChargeableDetailQuery chargeableDetailQuery = new GetChargeableDetailQuery(new DatabaseService());

            _chargeablesListQuery = chargeablesListQuery;
            _chargeableDetailQuery = chargeableDetailQuery;
        }


        [Route("")]
        public ViewResult Index()
        {
            var chargeables = _chargeablesListQuery.Execute();

            return View(chargeables);
        }

        [Route("{id:int}")]
        public ViewResult Detail(int id)
        {
            var chargeable = _chargeableDetailQuery.Execute(id);

            return View(chargeable);
        }
    }
}