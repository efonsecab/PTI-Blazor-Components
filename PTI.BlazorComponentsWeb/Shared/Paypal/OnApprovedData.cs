using System;
namespace PTI.BlazorComponentsWeb.Shared.Paypal
{
    public class OnApprovedData
    {
        public string orderID { get; set; }
        public string billingToken { get; set; }
        public string subscriptionID { get; set; }
        public string facilitatorAccessToken { get; set; }
        /*
         * YAYAYAY - Data:{"orderID":"0AG47086XK874125W","billingToken":"BA-6N589598S4700831G","subscriptionID":"I-3RM11A04T95L","facilitatorAccessToken":"A21AAE3DmB1sjP3JUw1SQzVoUX0iiH9px80W0uim8KxKXNjmKuUC1LBUQeuTHRHRqWGAj3exjdyPGMTcOf6CeW2nHYPsJyw4w"} Actions: {"order":{},"payment":null,"subscription":{}}
         * */
    }
}
