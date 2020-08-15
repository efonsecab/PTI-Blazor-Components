using System;
using Microsoft.AspNetCore.Components;

namespace PTI.BlazorComponents.SocialNetworks.Twitter
{
    public partial class TwitterShareButton
    {
        [Inject]
        public NavigationManager NavManager { get; set; }
        [Parameter]
        public bool AddWidgetsScript { get; set; } = false;
        [Parameter]
        public string UrlToShare { get; set; } = "https://www.twitter.com";
        [Parameter]
        public string ButtonText { get; set; } = "Tweet";
        [Parameter]
        public string TweetText { get; set; } = "Tweeted with PTI Blazor Components";
        /// <summary>
        /// Needs to be a comma separated list of strins
        /// </summary>
        [Parameter]
        public string HashTags { get; set; } = "MadeWithBlazor,dotnet,dotnetcore,blazor";

        public RenderFragment RenderButton()
        {
            RenderFragment html = (builder) =>
            {
                //<a href="https://twitter.com/share?ref_src=twsrc%5Etfw" class="twitter-share-button" data-size="large" data-text="PTI Custom Blazor Twitter Button" data-url="https://www.microsoft.com" data-hashtags="#Blazorrocks" data-show-count="false">Tweet</a><script async src="https://platform.twitter.com/widgets.js" charset="utf-8"></script>
                builder.OpenElement(0, "a");
                var refUrl = System.Web.HttpUtility.UrlPathEncode(NavManager.Uri);
                builder.AddAttribute(0, "href",$"https://twitter.com/share?ref_src={refUrl}");
                var dataUrl = System.Web.HttpUtility.UrlPathEncode(this.UrlToShare);
                builder.AddAttribute(0, "data-text", $"{TweetText}");
                builder.AddAttribute(0, "data-url", $"{dataUrl}");
                builder.AddAttribute(0, "data-size", $"large");
                builder.AddAttribute(0, "class", "twitter-share-button");
                builder.AddAttribute(0, "data-show-count",false);
                if (!String.IsNullOrWhiteSpace(this.HashTags))
                {
                    builder.AddAttribute(0, "data-hashtags", this.HashTags);
                }
                builder.AddContent(0, ButtonText);
                builder.CloseElement();
                if (AddWidgetsScript)
                {
                    builder.OpenElement(1, "script");
                    builder.AddAttribute(1, "async", true);
                    builder.AddAttribute(1, "src", "https://platform.twitter.com/widgets.js");
                    builder.AddAttribute(1, "charset", "utf-8");
                    builder.CloseElement();
                }
            };
            return html;
        }
    }
}
