using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-button-toolbar")]
  public class ButtonToolbarTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string ButtonToolbarClass { get; set; }

    public ButtonToolbarTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("btn-toolbar " + this.ButtonToolbarClass));
      output.Attributes.SetAttribute("data-toggle", (object) "buttons");
      output.Attributes.SetAttribute("role", (object) "toolbar");
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
