using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-panel-body")]
  public class PanelBodyTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string PanelBodyClass { get; set; }

    public PanelBodyTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("panel-body " + this.PanelBodyClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
