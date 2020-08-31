using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace PTI.BlazorComponents.Payments.Paypal
{
    public partial class SubscribeButton
    {
        [Inject]
        private IJSRuntime jsRuntime { get; set; }
        [Parameter]
        public string PlanName { get; set; }
        [Parameter]
        public bool AddPlatformScript { get; set; }
        [Parameter]
        public string ClientId { get; set; }
        [Parameter]
        public string PlanId { get; set; }
        [Parameter]
        public string ContainerId { get; set; } = "paypal-button-container";
        [Parameter]
        public string OnApproveJsFunction { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            object[] parameters= {$"#{this.ContainerId}", this.PlanId, OnApproveJsFunction };
            await this.jsRuntime.InvokeVoidAsync("RenderPaypalButton", parameters);
        }
    }
}
