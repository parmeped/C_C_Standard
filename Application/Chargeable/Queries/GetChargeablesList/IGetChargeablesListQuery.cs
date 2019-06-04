using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Chargeable.Queries.GetChargeablesList
{
    public interface IGetChargeablesListQuery
    {
        List<ChargeablesListItemModel> Execute();
    }
}
