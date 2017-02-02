using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-modal-header")]
  public class ModalHeaderTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string ModalHeaderClass { get; set; }

    public ModalHeaderTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("modal-header " + this.ModalHeaderClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
