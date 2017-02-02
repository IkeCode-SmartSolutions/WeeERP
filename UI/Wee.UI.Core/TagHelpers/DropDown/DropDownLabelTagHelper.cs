using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-dropdown-label")]
  public class DropDownLabelTagHelper : TagHelper
  {
    [HtmlAttributeName("id")]
    public string DropDownLabelId { get; set; }

    [HtmlAttributeName("type")]
    public string DropDownLabelType { get; set; }

    [HtmlAttributeName("class")]
    public string DropDownLabelClass { get; set; }

    [HtmlAttributeName("content")]
    public string DropDownLabelContent { get; set; }

    public DropDownLabelTagHelper()
    {
      
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      string str = this.DropDownLabelContent + "<span class='caret'></span>";
      output.Content.AppendHtml(str);
      output.Attributes.SetAttribute("id", (object) this.DropDownLabelId);
      output.Attributes.SetAttribute("class", (object) this.DropDownLabelClass);
      output.Attributes.SetAttribute("type", (object) "button");
      output.Attributes.SetAttribute("data-toggle", (object) "dropdown");
      output.Attributes.SetAttribute("aria-haspopup", (object) "true");
      output.Attributes.SetAttribute("aria-expanded", (object) "true");
      base.Process(context, output);
    }
  }
}
