using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Chargeable.Queries.GetChargeableDetail
{
    public interface IGetChargeableDetailQuery
    {
        ChargeableDetailModel Execute(int Id);

    }
}
