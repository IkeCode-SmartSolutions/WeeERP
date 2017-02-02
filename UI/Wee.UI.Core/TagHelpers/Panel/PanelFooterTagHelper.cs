using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-panel-footer")]
  public class PanelFooterTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string PanelFooterClass { get; set; }

    public PanelFooterTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("panel-footer " + this.PanelFooterClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
