using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-dropdown")]
  public class DropDownTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string DropDownClass { get; set; }

    public DropDownTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      (await output.GetChildContentAsync()).GetContent();
      output.Attributes.SetAttribute("class", (object) ("dropdown " + this.DropDownClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
