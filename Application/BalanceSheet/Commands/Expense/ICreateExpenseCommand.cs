namespace Application.BalanceSheet.Commands.Expense
{
    public interface ICreateExpenseCommand
    {
        void Execute(CreateExpenseModel model);
    }
}
