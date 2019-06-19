using System;

namespace Domain
{
    [Serializable]
    public class Member : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public Category Category { get; set; }
        public DateTime BirthDate { get; set; }    

        public BalanceSheet BalanceSheet { get; set; }
    }
}
