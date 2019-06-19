using Application.BalanceSheet.Commands.Payment.Factory;
using System.Collections.Generic;
using System.Linq;


namespace Application.BalanceSheet.Commands.Payment
{
    public class CreatePaymentCommand : ICreatePaymentCommand
    {
        private readonly IDatabaseService _database;
        private readonly IPaymentFactory _factory;

        public CreatePaymentCommand(
            IDatabaseService database,
            IPaymentFactory factory
            )
        {
            _database = database;
            _factory = factory;
        }

        public void Execute(CreatePaymentModel model)
        {
           
            List<Domain.Expense> expenses = new List<Domain.Expense>();
            for (int i = 0; i < model.Expenses.Count; i++)
            {
                var Eid = model.Expenses[i].ExpenseId;
                var Cid = model.Expenses[i].ChargeableId;

                var expense = _database.Expenses
                    .FirstOrDefault(x => x.Id == Eid);

                expense.Chargeable = _database.Chargeables
                    .FirstOrDefault(x => x.Id == Cid);

                expense.Paid = model.Expenses[i].Paid;

                expenses.Add(expense);

            }

            var Payment = _factory.Create(model.balanceSheetId, expenses);                               

            foreach (Domain.Expense exp in expenses)
            {
                var found = _database.Expenses.Find(exp.Id);
                _database.Expenses.Attach(found);
                found.Paid = exp.Paid;
            }

            _database.Payments.Add(Payment);

            _database.Save();
        }
    }
}

