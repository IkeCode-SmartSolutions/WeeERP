using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-carousel-indicators")]
  public class CarouselIndicatorsTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string CarouselIndicatorsClass { get; set; }

    public CarouselIndicatorsTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("carousel-indicators " + this.CarouselIndicatorsClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
