using System.Linq;

namespace Application.Chargeable.Queries.GetChargeableDetail
{
    public class GetChargeableDetailQuery
        : IGetChargeableDetailQuery
    {
        private readonly IDatabaseService _database;

        public GetChargeableDetailQuery(IDatabaseService database)
        {
            _database = database;
        }

        public ChargeableDetailModel Execute(int chargeableId)
        {
            var chargeable = _database.Chargeables
                .Where(x => x.Id == chargeableId)
                .Select(x => new ChargeableDetailModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Value = x.Value.ToString(),
                    Active = x.Active
                })
                .Single();

            return chargeable;
        }
    }
}
