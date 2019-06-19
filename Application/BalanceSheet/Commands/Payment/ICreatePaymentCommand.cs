namespace Application.BalanceSheet.Commands.Payment
{
    public interface ICreatePaymentCommand
    {
        void Execute(CreatePaymentModel model);
    }
}
