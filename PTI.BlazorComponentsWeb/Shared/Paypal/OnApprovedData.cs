using System;
namespace PTI.BlazorComponentsWeb.Shared.Paypal
{
    public class OnApprovedData
    {
        public string orderID { get; set; }
        public string billingToken { get; set; }
        public string subscriptionID { get; set; }
        public string facilitatorAccessToken { get; set; }
    }
}
