using Presentation.Payment.Models;

namespace Presentation
{
    public interface ICreatePaymentViewModelFactory
    {
        CreatePaymentViewModel Create(int BalanceSheetId);
    }
}