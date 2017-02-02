using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
    [HtmlTargetElement("bootstrap-badge")]
    public class BadgeTagHelper : TagHelper
    {
        [HtmlAttributeName("class")]
        public string BadgeClass { get; set; }

        public BadgeTagHelper() : base()
        {
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            TagHelperContent childContentAsync = await output.GetChildContentAsync();
            output.Content.AppendHtml(childContentAsync.GetContent());
            output.Attributes.SetAttribute("class", (object)("badge " + BadgeClass));
            
        }
    }
}
