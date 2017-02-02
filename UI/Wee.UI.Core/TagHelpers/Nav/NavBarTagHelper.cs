using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-nav-bar")]
  public class NavBarTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string NavBarClass { get; set; }

    [HtmlAttributeName("container")]
    public string NavBarContainer { get; set; }

    public NavBarTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      string content = (await output.GetChildContentAsync()).GetContent();
      string str = "navbar";
      output.Content.AppendHtml("<div class='" + this.NavBarContainer + "'>" + content + "</div>");
      if (this.NavBarClass.Length > 0)
        output.Attributes.SetAttribute("class", (object) (str + " " + this.NavBarClass));
      else
        output.Attributes.SetAttribute("class", (object) (str + " navbar navbar-default"));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
