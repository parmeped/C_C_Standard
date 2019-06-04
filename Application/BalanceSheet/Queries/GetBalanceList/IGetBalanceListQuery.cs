using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BalanceSheet.Queries.GetBalanceList
{
    public interface IGetBalanceListQuery
    {
        List<BalanceListItemModel> Execute();
    }
}
