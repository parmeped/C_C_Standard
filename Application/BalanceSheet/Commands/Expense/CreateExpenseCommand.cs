using Application.BalanceSheet.Commands.Expense.Factory;
using System.Linq;


namespace Application.BalanceSheet.Commands.Expense
{
    public class CreateExpenseCommand : ICreateExpenseCommand
    {
        private readonly IDatabaseService _database;
        private readonly IExpenseFactory _factory;

        public CreateExpenseCommand(
            IDatabaseService database,
            IExpenseFactory factory
            )
        {
            _database = database;
            _factory = factory;
        }

        public void Execute(CreateExpenseModel model)
        {
            var chargeable = _database.Chargeables
                .FirstOrDefault(x => x.Id == model.chargeableId);

            var Expense = _factory.Create(model.balanceSheetId, chargeable);

            _database.Expenses.Add(Expense);
            _database.Chargeables.Attach(chargeable);

            _database.Save();
        }
    }
}

