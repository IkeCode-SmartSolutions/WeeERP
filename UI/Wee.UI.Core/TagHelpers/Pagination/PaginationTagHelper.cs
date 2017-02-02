using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-pagination")]
  public class PaginationTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string PaginationClass { get; set; }

    [HtmlAttributeName("type")]
    public string PaginationType { get; set; }

    public PaginationTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.PreElement.AppendHtml("<bootstrap-pagination-nav>");
      output.PostElement.AppendHtml("</bootstrap-pagination-nav>");
      output.Attributes.SetAttribute("class", (object) (this.PaginationType + " " + this.PaginationClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
