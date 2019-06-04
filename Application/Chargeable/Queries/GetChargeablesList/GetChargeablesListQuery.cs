using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Chargeable.Queries.GetChargeablesList
{
    public class GetChargeablesListQuery : IGetChargeablesListQuery
    {
        private readonly IDatabaseService _database;

        public GetChargeablesListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<ChargeablesListItemModel> Execute()
        {
            var chargeables = _database.Chargeables
                .Select(x => new ChargeablesListItemModel()
                {
                    Id = x.Id,
                    Name = x.Name
                });

            return chargeables.ToList();
        }
    }
}
