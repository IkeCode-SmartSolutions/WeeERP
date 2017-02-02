using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-modal")]
  public class ModalTagHelper : TagHelper
  {
    [HtmlAttributeName("id")]
    public string ModalId { get; set; }

    [HtmlAttributeName("size")]
    public string ModalSize { get; set; }

    [HtmlAttributeName("class")]
    public string ModalClass { get; set; }

    public ModalTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      string content = (await output.GetChildContentAsync()).GetContent();
      string str = "modal-dialog";
      if (this.ModalSize == "sm" || this.ModalSize == "lg")
        str = "modal-dialog modal-" + this.ModalSize;
      output.Content.AppendHtml("<bootstrap-modal-dialog class='" + str + "'  role='document'><bootstrap-modal-content class='modal-content'>" + content + "</bootstrap-modal-content></bootstrap-modal-dialog>");
      output.Attributes.SetAttribute("id", (object) this.ModalId);
      output.Attributes.SetAttribute("class", (object) "modal");
      output.Attributes.SetAttribute("tabindex", (object) "-1");
      output.Attributes.SetAttribute("role", (object) "dialog");
      output.Attributes.SetAttribute("aria-labelledby", (object) "myModalLabel");
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
