using Application.BalanceSheet.Commands.Payment;
using Application.BalanceSheet.Queries.GetBalanceDetail;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Presentation.Payment.Models
{
    public class CreatePaymentViewModel
    {
        public List<EntryDetailModel> Expenses { get; set; }        

        public int balanceSheetId { get; set; }       

        public CreatePaymentModel Payment { get; set; }
        
    }
}