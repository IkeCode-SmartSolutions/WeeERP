using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-well")]
  public class WellTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string WellClass { get; set; }

    public WellTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("well " + this.WellClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
