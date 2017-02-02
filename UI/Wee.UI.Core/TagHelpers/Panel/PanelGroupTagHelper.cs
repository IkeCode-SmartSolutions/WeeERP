using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-panel-group")]
  public class PanelGroupTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string PanelClass { get; set; }

    public PanelGroupTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("panel-group " + this.PanelClass));
      output.Attributes.SetAttribute("role", (object) "tablist");
      output.Attributes.SetAttribute("aria-multiselectable", (object) "true");
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
