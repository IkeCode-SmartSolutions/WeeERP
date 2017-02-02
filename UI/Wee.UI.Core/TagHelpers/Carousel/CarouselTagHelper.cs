using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-carousel")]
  public class CarouselTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string CarouselClass { get; set; }

    public CarouselTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) (this.CarouselClass + " carousel"));
      output.Attributes.SetAttribute("data-ride", (object) "carousel");
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
