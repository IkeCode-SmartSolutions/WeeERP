using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using System;

namespace Wee.UI.Core.TagHelpers
{
    [HtmlTargetElement("bootstrap-alert-close")]
    public class AlertCloseTagHelper : TagHelper
    {        
        //public override AlertCloseTagHelper Self
        //{
        //    get
        //    {
        //        return this;
        //    }
        //}

        public AlertCloseTagHelper(IServiceProvider serviceProvider)
                //: base(serviceProvider)
        {

        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            TagHelperContent childContentAsync = await output.GetChildContentAsync();
            output.Content.AppendHtml(childContentAsync.GetContent());
            output.Attributes.SetAttribute("type", (object)"button");
            output.Attributes.SetAttribute("class", (object)("close " + this.AlertCloseClass));
            output.Attributes.SetAttribute("data-dismiss", (object)"alert");
            output.Attributes.SetAttribute("aria-label", (object)"Close");

            await base.ProcessAsync(context, output);
        }

        [HtmlAttributeName("class")]
        public string AlertCloseClass { get; set; }
    }
}
