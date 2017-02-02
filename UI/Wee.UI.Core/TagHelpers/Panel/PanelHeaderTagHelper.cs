using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-panel-header")]
  public class PanelHeaderTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string PanelHeaderClass { get; set; }

    public PanelHeaderTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("panel-heading " + this.PanelHeaderClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
