using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-panel")]
  public class PanelTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string PanelClass { get; set; }

    public PanelTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("panel " + this.PanelClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
