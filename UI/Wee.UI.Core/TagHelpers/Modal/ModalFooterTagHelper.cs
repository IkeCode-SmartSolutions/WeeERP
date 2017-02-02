using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-modal-footer")]
  public class ModalFooterTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string ModalFooterClass { get; set; }

    public ModalFooterTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("modal-footer " + this.ModalFooterClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
