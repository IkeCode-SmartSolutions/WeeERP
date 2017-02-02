using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-carousel-caption")]
  public class CarouselCaptionTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string CarouselCaptionClass { get; set; }

    public CarouselCaptionTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("carousel-caption " + this.CarouselCaptionClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
