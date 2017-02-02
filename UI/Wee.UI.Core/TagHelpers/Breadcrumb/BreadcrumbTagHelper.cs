using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-breadcrumb")]
  public class BreadcrumbTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string BreadcrumbClass { get; set; }

    public BreadcrumbTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("breadcrumb " + this.BreadcrumbClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
