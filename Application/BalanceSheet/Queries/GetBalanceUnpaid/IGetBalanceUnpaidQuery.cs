namespace Application.BalanceSheet.Queries.GetBalanceUnpaid
{
    public interface IGetBalanceUnpaidQuery
    {
        BalanceUnpaidModel Execute(int Id);

    }
}
