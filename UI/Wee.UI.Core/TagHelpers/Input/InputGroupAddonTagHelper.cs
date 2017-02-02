using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-input-group-addon")]
  public class InputGroupAddonTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string InputGroupAddonClass { get; set; }

    [HtmlAttributeName("type")]
    public string InputGroupAddonType { get; set; }

    public InputGroupAddonTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      string content = (await output.GetChildContentAsync()).GetContent();
      string str = "input-group-addon";
      if (this.InputGroupAddonType == "button")
        str = "input-group-btn";
      output.Content.AppendHtml(content);
      if (this.InputGroupAddonClass.Length > 0)
        output.Attributes.SetAttribute("class", (object) (str + " " + this.InputGroupAddonClass));
      else
        output.Attributes.SetAttribute("class", (object) str);
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
