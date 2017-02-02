using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-alert")]
  public class AlertTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string AlertClass { get; set; }

    public AlertTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("alert " + this.AlertClass));
      output.Attributes.SetAttribute("role", (object) "alert");
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
