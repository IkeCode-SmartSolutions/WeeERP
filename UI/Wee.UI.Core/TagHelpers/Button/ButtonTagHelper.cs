using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Wee.UI.Core.TagHelpers
{
    [HtmlTargetElement("bootstrap-button")]
    public class ButtonTagHelper : WeeTagHelper<ButtonTagHelper>
    {
        public override ButtonTagHelper Self { get { return this; } }

        public override TagBuilder Builder
        {
            get
            {
                if (ButtonElement == "a")
                {
                    return new TagBuilder("a");
                }
                else if (ButtonElement == "input")
                {
                    return new TagBuilder("input");
                }
                else
                {
                    return new TagBuilder("button");
                }
            }
        }

        public ButtonTagHelper(IServiceProvider serviceProvider/*, IAweOverrideTagHelper<ButtonTagHelper> overrider*/)
            : base(serviceProvider/*, overrider*/)
        {
        }

        public override async Task ProcessAsync(TagBuilder builder, TagHelperContext context, TagHelperOutput output)
        {
            string btnValue = ButtonValue.Length <= 0 ? (await output.GetChildContentAsync()).GetContent() : ButtonValue;

            if (Array.IndexOf<string>(allowedButtonElements, ButtonElement) == -1)
                throw new ArgumentException("Invalid element! Please, use one of the following HTML elements - 'a', 'button' or 'input'");

            if (Array.IndexOf<string>(allowedButtonTypes, ButtonType) == -1)
                throw new ArgumentException("Invalid button type! Please, use one of the following types - 'button', 'submit' or 'reset'");

            if (Array.IndexOf<string>(allowedButtonOptions, ButtonOption) == -1)
                throw new ArgumentException("Invalid button option! Please, use one of the following options - 'default', 'primary', 'success', 'info', 'warning', 'danger' or 'link'");

            string btnOption = "btn-" + ButtonOption;
            ButtonClass += $" btn {btnOption}";

            string btnDisabled = "";
            if (ButtonDisabled)
                btnDisabled = !(ButtonElement == "a") ? "disabled='disabled'" : "disabled";

            string str4;

            var attrs = new Dictionary<string, string>();
            
            if (ButtonElement == "a")
            {
                attrs.Add("target", ButtonTarget);

                str4 = string.Format("<a href='{0}' target='{1}' role='{2}' class='{3}' id='{4}' autocomplete='{5}' data-loading-text='{6}'>{7}</a>", (object)ButtonLink, (object)ButtonTarget, (object)ButtonType, (object)ButtonClass, (object)ButtonId, (object)ButtonAutocomplete, (object)ButtonLoadingText, (object)btnValue);
            }
            else if (ButtonElement == "input")
            {
                attrs.Add("value", btnValue);
                attrs.Add("type", ButtonType);
                str4 = string.Format("<input type='{0}' class='{1}' {2} value='{3}' id='{4}' autocomplete='{5}' data-loading-text='{6}'/>", (object)ButtonType, (object)ButtonClass, (object)btnDisabled, (object)btnValue, (object)ButtonId, (object)ButtonAutocomplete, (object)ButtonLoadingText);
            }
            else
            {
                attrs.Add("type", ButtonType);
                str4 = string.Format("<button type='{0}' class='{1}' {2}  id='{3}' autocomplete='{4}' data-loading-text='{5}'>{6}</button>", (object)ButtonType, (object)ButtonClass, (object)btnDisabled, (object)ButtonId, (object)ButtonAutocomplete, (object)ButtonLoadingText, (object)btnValue);
            }

            attrs.Add("id", ButtonId);
            attrs.Add("autocomplete", ButtonAutocomplete);
            attrs.Add("data-loading-text", ButtonLoadingText);

            builder.InnerHtml.Append(btnValue);
            
            builder.AddCssClass(ButtonClass);
            builder.MergeAttributes(attrs);

            output.Content.SetHtmlContent(builder);

            //output.Content.AppendHtml(str4);
        }

        #region Properties

        [HtmlAttributeName("element")]
        public string ButtonElement { get; set; }

        [HtmlAttributeName("id")]
        public string ButtonId { get; set; }

        [HtmlAttributeName("autocomplete")]
        public string ButtonAutocomplete { get; set; }

        [HtmlAttributeName("loading-text")]
        public string ButtonLoadingText { get; set; }

        [HtmlAttributeName("class")]
        public string ButtonClass { get; set; }

        [HtmlAttributeName("type")]
        public string ButtonType { get; set; }

        [HtmlAttributeName("option")]
        public string ButtonOption { get; set; }

        [HtmlAttributeName("size")]
        public string ButtonSize { get; set; }

        [HtmlAttributeName("active")]
        public bool ButtonActive { get; set; }

        [HtmlAttributeName("disabled")]
        public bool ButtonDisabled { get; set; }

        [HtmlAttributeName("block")]
        public bool ButtonBlock { get; set; }

        [HtmlAttributeName("value")]
        public string ButtonValue { get; set; }

        [HtmlAttributeName("link")]
        public string ButtonLink { get; set; }

        [HtmlAttributeName("target")]
        public string ButtonTarget { get; set; }

        readonly string[] allowedButtonElements = new string[3]
            {
                "a",
                "button",
                "input"
            };

        readonly string[] allowedButtonTypes = new string[3]
        {
                "button",
                "submit",
                "reset"
        };

        readonly string[] allowedButtonOptions = new string[7]
        {
                "default",
                "primary",
                "success",
                "info",
                "warning",
                "danger",
                "link"
        };

        readonly string[] allowedButtonSizes = new string[4]
        {
                "default",
                "large",
                "small",
                "extrasmall"
        };

        #endregion Properties
    }

    public enum ButtonElement
    {
        Link,
        Input,
        Button
    };

    public enum ButtonType
    {
        Button,
        Submit,
        Reset
    };

    public enum ButtonOption
    {
        Default,
        Primary,
        Success,
        Info,
        Warning,
        Danger,
        Link
    }

    public enum ButtonSize
    {
        Default,
        Large,
        Small,
        Extrasmall
    };
}
