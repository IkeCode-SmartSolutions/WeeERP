using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-dropdown-menu-header")]
  public class DropDownMenuHeaderTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string DropDownMenuHeader { get; set; }

    public DropDownMenuHeaderTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("dropdown-header " + this.DropDownMenuHeader));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
