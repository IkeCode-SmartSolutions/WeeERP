using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-dropup")]
  public class DropUpTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string DropupClass { get; set; }

    public DropUpTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      (await output.GetChildContentAsync()).GetContent();
      output.Attributes.SetAttribute("class", (object) ("dropup " + this.DropupClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
