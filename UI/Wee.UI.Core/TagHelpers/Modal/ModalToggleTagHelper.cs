using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement(Attributes = "bootstrap-toggle-modal")]
  public class ModalToggleTagHelper : TagHelper
  {
    [HtmlAttributeName("bootstrap-toggle-modal")]
    public string ToggleModal { get; set; }

    public ModalToggleTagHelper()
    {
      
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      output.Attributes.SetAttribute("data-toggle", (object) "modal");
      output.Attributes.SetAttribute("data-target", (object) string.Format("#{0}", (object) this.ToggleModal));
    }
  }
}
