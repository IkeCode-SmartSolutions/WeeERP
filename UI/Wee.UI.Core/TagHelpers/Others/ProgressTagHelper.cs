using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-progress")]
  public class ProgressTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string ProgressClass { get; set; }

    public ProgressTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      (await output.GetChildContentAsync()).GetContent();
      output.Attributes.SetAttribute("class", (object) ("progress " + this.ProgressClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
