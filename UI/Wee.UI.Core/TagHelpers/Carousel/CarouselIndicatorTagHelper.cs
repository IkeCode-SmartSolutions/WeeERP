using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-carousel-indicator")]
  public class CarouselIndicatorTagHelper : TagHelper
  {
    [HtmlAttributeName("active")]
    public bool CarouselIndicatorActive { get; set; }

    [HtmlAttributeName("class")]
    public string CarouselIndicatorClass { get; set; }

    [HtmlAttributeName("slide-to")]
    public string CarouselIndicatorSlideTo { get; set; }

    [HtmlAttributeName("target")]
    public string CarouselIndicatorTarget { get; set; }

    public CarouselIndicatorTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      if (this.CarouselIndicatorActive)
        output.Attributes.SetAttribute("class", (object) (this.CarouselIndicatorClass + " active"));
      else
        output.Attributes.SetAttribute("class", (object) this.CarouselIndicatorClass);
      output.Attributes.SetAttribute("data-slide-to", (object) this.CarouselIndicatorSlideTo);
      output.Attributes.SetAttribute("data-target", (object) this.CarouselIndicatorTarget);
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
