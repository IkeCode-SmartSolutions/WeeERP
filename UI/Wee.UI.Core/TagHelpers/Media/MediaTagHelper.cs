using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-media")]
  public class MediaTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string MediaClass { get; set; }

    public MediaTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("media-list " + this.MediaClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
