using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-media-right")]
  public class MediaRightTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string MediaRightClass { get; set; }

    public MediaRightTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("media-right " + this.MediaRightClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
