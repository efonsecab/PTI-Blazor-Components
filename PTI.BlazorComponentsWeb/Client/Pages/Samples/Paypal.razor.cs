using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PTI.BlazorComponentsWeb.Shared.Paypal;

namespace PTI.BlazorComponentsWeb.Client.Pages.Samples
{
    public partial class Paypal
    {
        [Inject]
        private HttpClient httpClient { get; set; }
        private static HttpClient StaticHttpClient { get; set; }

        protected override void OnInitialized()
        {
            StaticHttpClient = this.httpClient;
        }

        [JSInvokable()]
        public static async Task OnApproved(OnApprovedData data, object actions)
        {
            await StaticHttpClient.PostAsJsonAsync<OnApprovedData>("Paypal/UserSubscribed", data);
        }
    }
}
