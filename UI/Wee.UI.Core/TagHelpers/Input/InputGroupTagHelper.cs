using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-input-group")]
  public class InputGroupTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string InputGroupClass { get; set; }

    public InputGroupTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("input-group " + this.InputGroupClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
