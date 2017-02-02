using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-collapse")]
  public class CollapseTagHelper : TagHelper
  {
    [HtmlAttributeName("trigger")]
    public string CollapseTrigger { get; set; }

    [HtmlAttributeName("id")]
    public string CollapseId { get; set; }

    [HtmlAttributeName("class")]
    public string CollapseClass { get; set; }

    public CollapseTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      (await output.GetChildContentAsync()).GetContent();
      output.PostContent.AppendHtml("<script>$(function() { $('" + this.CollapseTrigger + "').on('click', function () { $('#" + this.CollapseId + "').collapse('toggle'); }); });</script>");
      output.Attributes.SetAttribute("class", (object) ("collapse " + this.CollapseClass));
      output.Attributes.SetAttribute("id", (object) this.CollapseId);
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
