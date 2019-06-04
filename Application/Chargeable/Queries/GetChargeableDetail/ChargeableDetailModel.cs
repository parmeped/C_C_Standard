using System;

namespace Application.Chargeable.Queries.GetChargeableDetail
{
    public class ChargeableDetailModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Value { get; set; }
        public Boolean Active { get; set; }

    }
}
