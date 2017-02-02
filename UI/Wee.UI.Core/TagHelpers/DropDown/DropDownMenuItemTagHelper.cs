using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-dropdown-menu-item")]
  public class DropDownMenuItemTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string DropDownItemClass { get; set; }

    public DropDownMenuItemTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("bootstrap-dropdown-menu-item " + this.DropDownItemClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
