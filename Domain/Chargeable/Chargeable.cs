using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Chargeable : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Value { get; set; }
        public Boolean Active { get; set; }

    }
}
