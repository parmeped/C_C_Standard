
namespace Application.Member.Queries.GetMemberDetail
{
    public class MemberDetailModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Domain.Category Category { get; set; }

        public string BirthDate { get; set; }

        public Domain.BalanceSheet BalanceSheet { get; set; }

    }
}
