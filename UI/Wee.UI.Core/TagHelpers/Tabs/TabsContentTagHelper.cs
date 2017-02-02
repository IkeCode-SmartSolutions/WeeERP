using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-tabs-content")]
  public class TabsContentTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string TabsContentClass { get; set; }

    public TabsContentTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("tab-content " + this.TabsContentClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
