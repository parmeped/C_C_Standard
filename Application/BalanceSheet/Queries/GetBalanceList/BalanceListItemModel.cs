namespace Application.BalanceSheet.Queries.GetBalanceList
{
    public class BalanceListItemModel
    {
        public int Id { get; set; }

        public Domain.Member Member { get; set; }

        public decimal Total { get; set; }

    }
}
