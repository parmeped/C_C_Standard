using System;

namespace Application.Member.Commands
{
    public class CreateMemberModel
    {
        public string Name { get; set; }
        public Domain.Category Category { get; set; }
        public DateTime BirthDate { get; set; }
        public Domain.BalanceSheet BalanceSheet { get; set; }
    }
}
