using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-media-left")]
  public class MediaLeftTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string MediaLeftClass { get; set; }

    public MediaLeftTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("media-left " + this.MediaLeftClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
