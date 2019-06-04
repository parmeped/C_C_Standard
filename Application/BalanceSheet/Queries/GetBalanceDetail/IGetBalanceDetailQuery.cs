using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BalanceSheet.Queries.GetBalanceDetail
{
    public interface IGetBalanceDetailQuery
    {
        BalanceDetailModel Execute(int Id);

    }
}
