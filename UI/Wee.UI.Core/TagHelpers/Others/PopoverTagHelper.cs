using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("div", Attributes = "bootstrap-popover")]
  [HtmlTargetElement("img", Attributes = "bootstrap-popover")]
  [HtmlTargetElement("span", Attributes = "bootstrap-popover")]
  [HtmlTargetElement("nav", Attributes = "bootstrap-popover")]
  [HtmlTargetElement("button", Attributes = "bootstrap-popover")]
  [HtmlTargetElement("a", Attributes = "bootstrap-popover")]
  [HtmlTargetElement("p", Attributes = "bootstrap-popover")]
  [HtmlTargetElement("h1", Attributes = "bootstrap-popover")]
  [HtmlTargetElement("h2", Attributes = "bootstrap-popover")]
  [HtmlTargetElement("h3", Attributes = "bootstrap-popover")]
  [HtmlTargetElement("h4", Attributes = "bootstrap-popover")]
  [HtmlTargetElement("h5", Attributes = "bootstrap-popover")]
  [HtmlTargetElement("h6", Attributes = "bootstrap-popover")]
  [HtmlTargetElement("bootstrap-button", Attributes = "bootstrap-popover")]
  public class PopoverTagHelper : TagHelper
  {
    [HtmlAttributeName("bootstrap-popover")]
    public string PopoverTitle { get; set; }

    [HtmlAttributeName("id")]
    public string PopoverId { get; set; }

    [HtmlAttributeName("static")]
    public bool PopoverStatic { get; set; }

    [HtmlAttributeName("placement")]
    public string PopoverPlacement { get; set; }

    [HtmlAttributeName("title")]
    public string PopoverTitle1 { get; set; }

    [HtmlAttributeName("content")]
    public string PopoverContent { get; set; }

    public PopoverTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      (await output.GetChildContentAsync()).GetContent();
      if (!this.PopoverStatic)
      {
        if (this.PopoverTitle != "")
          output.PostElement.AppendHtml("<script>$(function() {$('#" + this.PopoverId + "').popover();});</script>");
        output.Attributes.SetAttribute("data-toggle", (object) "popover");
        output.Attributes.SetAttribute("title", (object) this.PopoverTitle1);
        output.Attributes.SetAttribute("id", (object) this.PopoverId);
      }
      else
      {
        output.Content.AppendHtml("<div class='arrow'></div> <h3 class='popover-title'>" + this.PopoverTitle1 + "</h3><div class='popover-content'><p>" + this.PopoverContent + "</p></div>");
        output.Attributes.SetAttribute("class", (object) ("popover static " + this.PopoverPlacement));
        output.Attributes.SetAttribute("id", (object) this.PopoverId);
      }
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
