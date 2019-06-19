
namespace Application.BalanceSheet.Commands.Payment
{
    public class ExpenseModel
    {
        public int ExpenseId { get; set; }

        public int ChargeableId { get; set; }
        public bool Paid { get; set; }
        
    }
}