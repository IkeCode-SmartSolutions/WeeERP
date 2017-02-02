using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-button-group")]
  public class ButtonGroupTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string ButtonGroupClass { get; set; }

    [HtmlAttributeName("orientation")]
    public string ButtonGroupOrientation { get; set; }

    public ButtonGroupTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      string content = (await output.GetChildContentAsync()).GetContent();
      string str = "btn-group";
      if (this.ButtonGroupOrientation == "vertical")
        str = "btn-group-vertical";
      output.Content.AppendHtml(content);
      output.Attributes.SetAttribute("class", (object) (str + " " + this.ButtonGroupClass));
      output.Attributes.SetAttribute("data-toggle", (object) "buttons");
      output.Attributes.SetAttribute("role", (object) "group");
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
