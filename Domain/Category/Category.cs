using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    [Serializable]
    public class Category : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public Chargeable Chargeable { get; set; }
    }
}
