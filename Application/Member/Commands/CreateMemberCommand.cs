using Application.Member.Commands.Factory;
using System.Linq;


namespace Application.Member.Commands
{
    public class CreateMemberCommand : ICreateMemberCommand
    {
        private readonly IDatabaseService _database;
        private readonly IMemberFactory _factory;

        public CreateMemberCommand(
            IDatabaseService database,
            IMemberFactory factory
            )
        {
            _database = database;
            _factory = factory;
        }

        public void Execute(CreateMemberModel model)
        {
            var category = _database.Categories
                .FirstOrDefault(x => x.Id == model.Category.Id);

            var Member = _factory.Create(
                model.Name,
                category,
                model.BirthDate);

            int _Id = (from x in _database.BalanceSheets
                orderby x.Id descending
                select x.Id).FirstOrDefault();
            _Id++;

            Domain.BalanceSheet balanceSheet = new Domain.BalanceSheet() { Id = _Id };
            Member.BalanceSheet = balanceSheet;
                                 
            _database.Members.Add(Member);

            _database.Save();
        }
    }
}

