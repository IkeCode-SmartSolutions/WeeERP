using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-carousel-control")]
  public class CarouselControlTagHelper : TagHelper
  {
    [HtmlAttributeName("type")]
    public string CollapseCarouselType { get; set; }

    [HtmlAttributeName("slide")]
    public string CollapseCarouselSlide { get; set; }

    [HtmlAttributeName("class")]
    public string CarouselControlClass { get; set; }

    [HtmlAttributeName("target")]
    public string CollapseCarouselTarget { get; set; }

    public CarouselControlTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) (this.CollapseCarouselType + " carousel-control " + this.CarouselControlClass));
      output.Attributes.SetAttribute("href", (object) this.CollapseCarouselTarget);
      output.Attributes.SetAttribute("role", (object) "button");
      output.Attributes.SetAttribute("data-slide", (object) this.CollapseCarouselSlide);
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
