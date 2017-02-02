using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-nav-item")]
  public class NavItemTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string NavItemClass { get; set; }

    public NavItemTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) this.NavItemClass);
      output.Attributes.SetAttribute("role", (object) "presentation");
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
