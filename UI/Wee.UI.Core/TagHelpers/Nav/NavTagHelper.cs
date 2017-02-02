using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-nav")]
  public class NavTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string NavClass { get; set; }

    public NavTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("nav " + this.NavClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
