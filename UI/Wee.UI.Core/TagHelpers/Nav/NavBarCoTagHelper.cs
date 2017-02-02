using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-nav-bar-collapse")]
  public class NavBarCoTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string NavBarCollapseClass { get; set; }

    public NavBarCoTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("collapse navbar-collapse " + this.NavBarCollapseClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
