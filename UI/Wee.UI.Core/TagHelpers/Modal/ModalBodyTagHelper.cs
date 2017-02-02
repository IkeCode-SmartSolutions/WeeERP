using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-modal-body")]
  public class ModalBodyTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string ModalBodyClass { get; set; }

    public ModalBodyTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("modal-body " + this.ModalBodyClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
