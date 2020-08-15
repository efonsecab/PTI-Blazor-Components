using System;
using Microsoft.AspNetCore.Components;

namespace PTI.BlazorComponents.SocialNetworks.LinkedIn
{
    public partial class LinkedInShareButton
    {
        private bool BlockRender { get; set; } = false;
        [Parameter]
        public bool AddPlatformScript { get; set; } = false;
        [Parameter]
        public string UrlToShare { get; set; } = "https://www.linkedin.com";

        public RenderFragment RenderButton()
        {
            RenderFragment form = b =>
            {
                int index = 0;
                if (this.AddPlatformScript)
                {
                    b.OpenElement(index, "script");
                    b.AddAttribute(index, "src", "https://platform.linkedin.com/in.js");
                    b.AddAttribute(index, "type", "text/javascript");
                    b.CloseElement();
                    index++;
                }
                b.OpenElement(index, "script");
                b.AddAttribute(index, "data-url", $"{this.UrlToShare}");
                b.AddAttribute(index, "type", "IN/Share");
                b.CloseElement();
            };
            return form;
        }
    }
}
