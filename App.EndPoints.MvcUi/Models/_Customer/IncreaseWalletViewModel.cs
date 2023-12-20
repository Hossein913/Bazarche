using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace App.EndPoints.MvcUi.Models._Customer
{
    public class IncreaseWalletViewModel
    {  
        [Display(Name="مبلغ")]
        public int Amount { get; set; }
    }
}
