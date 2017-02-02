using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-modal-fade")]
  public class ModalFadeTagHelper : TagHelper
  {
    public ModalFadeTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      (await output.GetChildContentAsync()).GetContent();
      output.Attributes.SetAttribute("class", (object) "modal");
      output.Attributes.SetAttribute("tabindex", (object) "-1");
      output.Attributes.SetAttribute("role", (object) "dialog");
      output.Attributes.SetAttribute("aria-labelledby", (object) "myModalLabel");
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
