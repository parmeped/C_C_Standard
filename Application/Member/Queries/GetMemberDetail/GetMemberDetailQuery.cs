using System.Linq;

namespace Application.Member.Queries.GetMemberDetail
{
    public class GetMemberDetailQuery 
            :IGetMemberDetailQuery
    {
        private readonly IDatabaseService _database;

        public GetMemberDetailQuery(IDatabaseService database)
        {
            _database = database;
        }

        public MemberDetailModel Execute(int memberId)
        {
            var member = _database.Members
                .Where(x => x.Id == memberId)
                .Select(x => new MemberDetailModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category,
                    BirthDate = x.BirthDate.ToString(),
                    BalanceSheet = x.BalanceSheet
                })
                .Single();

            return member;
        }
    }
}
