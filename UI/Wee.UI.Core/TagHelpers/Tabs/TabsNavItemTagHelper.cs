using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-tab")]
  public class TabsNavItemTagHelper : TagHelper
  {
    [HtmlAttributeName("active")]
    public bool Active { get; set; }

    [HtmlAttributeName("class")]
    public string TabClass { get; set; }

    public TabsNavItemTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("role", (object) "presentation");
      if (this.Active)
        output.Attributes.SetAttribute("class", (object) ("active " + this.TabClass));
      else
        output.Attributes.SetAttribute("class", (object) this.TabClass);
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
