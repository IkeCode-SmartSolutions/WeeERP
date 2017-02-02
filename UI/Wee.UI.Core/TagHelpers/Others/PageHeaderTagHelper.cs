using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-page-header")]
  public class PageHeaderTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string PageHeaderClass { get; set; }

    public PageHeaderTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("page-header " + this.PageHeaderClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
