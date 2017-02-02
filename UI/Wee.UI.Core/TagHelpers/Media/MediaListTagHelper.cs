using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-media-list")]
  public class MediaListTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string MediaListClass { get; set; }

    public MediaListTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("media-list " + this.MediaListClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
