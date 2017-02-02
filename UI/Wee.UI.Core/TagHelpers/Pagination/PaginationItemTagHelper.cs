using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-pagination-item")]
  public class PaginationItemTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string PaginationItemClass { get; set; }

    public PaginationItemTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) this.PaginationItemClass);
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
