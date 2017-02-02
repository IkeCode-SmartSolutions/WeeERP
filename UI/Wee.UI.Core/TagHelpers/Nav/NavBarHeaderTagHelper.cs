using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-nav-bar-header")]
  public class NavBarHeaderTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string NavBarHeaderClass { get; set; }

    public NavBarHeaderTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("navbar-header " + this.NavBarHeaderClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
