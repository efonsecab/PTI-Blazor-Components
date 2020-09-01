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
        public string OnApproveFunctionAssembly { get; set; }
        [Parameter]
        public string OnApproveFunctionName { get; set; }
        private bool CanRenderButtons { get; set; } = false;
        private bool IsLoading { get; set; } = true;

        protected override void OnInitialized()
        {
            if (!this.AddPlatformScript)
                this.CanRenderButtons = true;
        }

        protected RenderFragment RenderPaypalSdk
        {
            get
            {
                RenderFragment form = b =>
                {
                    //<script src="https://www.paypal.com/sdk/js?client-id=Acehjsg6Q8wB2xIYyKohTjB1qToyHV_PPHqpsN3pcfS9YX2LqZD24g5nJzeZIWdGgFVQOLi0OUMjJ5Ij&vault=true" data-sdk-integration-source="button-factory"></script>
                    b.OpenElement(0, "script");
                    b.AddAttribute(0, "src", $"https://www.paypal.com/sdk/js" +
                        $"?client-id={this.ClientId}" +
                        $"&vault=true");
                    b.AddAttribute(0, "data-sdk-integration-source", "button-factory");
                    b.CloseElement();
                };
                this.CanRenderButtons = true;
                return form;
            }
        }

        private async Task RenderButtons()
        {
            object[] parameters = {$"#{this.ContainerId}", this.PlanId,
                OnApproveFunctionAssembly, OnApproveFunctionName };
            await this.jsRuntime.InvokeVoidAsync("RenderPaypalButton", parameters);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (this.CanRenderButtons && this.IsLoading)
            {
                await Task.Delay(5000);
                await RenderButtons();
                this.IsLoading = false;
                StateHasChanged();
            }
        }
    }
}
