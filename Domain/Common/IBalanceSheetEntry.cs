using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
    public interface IBalanceSheetEntry : IEntity
    {        
        decimal Total { get; }
    }
}
