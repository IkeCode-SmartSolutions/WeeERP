using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-media-body")]
  public class MediaBodyTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string MediaBodyClass { get; set; }

    public MediaBodyTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("media-body " + this.MediaBodyClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
