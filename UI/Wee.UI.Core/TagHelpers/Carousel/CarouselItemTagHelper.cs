using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-carousel-item")]
  public class CarouselItemTagHelper : TagHelper
  {
    [HtmlAttributeName("active")]
    public bool CarouselItemActive { get; set; }

    [HtmlAttributeName("class")]
    public string CarouselItemClass { get; set; }

    public CarouselItemTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      if (this.CarouselItemActive)
        output.Attributes.SetAttribute("class", (object) ("item active " + this.CarouselItemClass));
      else
        output.Attributes.SetAttribute("class", (object) ("item " + this.CarouselItemClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
