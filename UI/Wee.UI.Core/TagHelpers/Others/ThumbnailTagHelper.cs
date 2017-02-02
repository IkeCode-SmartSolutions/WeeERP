using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-thumbnail")]
  public class ThumbnailTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string ThumbnailClass { get; set; }

    [HtmlAttributeName("href")]
    public string ThumbnailHref { get; set; }

    public ThumbnailTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("thumbnail " + this.ThumbnailClass));
      if (this.ThumbnailHref.Length > 0)
      {
        output.TagName = "a";
        output.Attributes.SetAttribute("href", (object) this.ThumbnailHref);
      }
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
