using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-tab-pane")]
  public class TabsContentItemTagHelper : TagHelper
  {
    [HtmlAttributeName("active")]
    public bool Active { get; set; }

    [HtmlAttributeName("class")]
    public string Class { get; set; }

    public TabsContentItemTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      string tabPaneClass = "tab-pane";
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("role", (object) "tabpanel");
      if (this.Class.Length > 0)
        tabPaneClass = tabPaneClass + " " + this.Class;
      if (this.Active)
        tabPaneClass += " active";
      output.Attributes.SetAttribute("class", (object) tabPaneClass);
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
