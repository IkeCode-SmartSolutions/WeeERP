using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-carousel-items")]
  public class CarouselItemsTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string CarouselItemsClass { get; set; }

    public CarouselItemsTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("carousel-inner " + this.CarouselItemsClass));
      output.Attributes.SetAttribute("role", (object) "listbox");
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
