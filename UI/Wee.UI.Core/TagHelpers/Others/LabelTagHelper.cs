using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-label")]
  public class LabelTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string LabelClass { get; set; }

    public LabelTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("label " + this.LabelClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
