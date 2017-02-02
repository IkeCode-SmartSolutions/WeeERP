using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("div", Attributes = "bootstrap-tooltip")]
  [HtmlTargetElement("img", Attributes = "bootstrap-tooltip")]
  [HtmlTargetElement("span", Attributes = "bootstrap-tooltip")]
  [HtmlTargetElement("nav", Attributes = "bootstrap-tooltip")]
  [HtmlTargetElement("button", Attributes = "bootstrap-tooltip")]
  [HtmlTargetElement("a", Attributes = "bootstrap-tooltip")]
  [HtmlTargetElement("p", Attributes = "bootstrap-tooltip")]
  [HtmlTargetElement("h1", Attributes = "bootstrap-tooltip")]
  [HtmlTargetElement("h2", Attributes = "bootstrap-tooltip")]
  [HtmlTargetElement("h3", Attributes = "bootstrap-tooltip")]
  [HtmlTargetElement("h4", Attributes = "bootstrap-tooltip")]
  [HtmlTargetElement("h5", Attributes = "bootstrap-tooltip")]
  [HtmlTargetElement("h6", Attributes = "bootstrap-tooltip")]
  [HtmlTargetElement("bootstrap-button", Attributes = "bootstrap-tooltip")]
  public class TooltipTagHelper : TagHelper
  {
    [HtmlAttributeName("bootstrap-tooltip-toggle")]
    public string TooltipToggle { get; set; }

    [HtmlAttributeName("bootstrap-tooltip")]
    public string TooltipTitle { get; set; }

    [HtmlAttributeName("static")]
    public bool TooltipStatic { get; set; }

    [HtmlAttributeName("placement")]
    public string TooltipPlacement { get; set; }

    public TooltipTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      string content = (await output.GetChildContentAsync()).GetContent();
      if (!this.TooltipStatic)
      {
        if (this.TooltipToggle == "")
          this.TooltipToggle = this.TooltipTitle;
        if (this.TooltipTitle != "")
        {
          output.PostElement.AppendHtml("<script>$(function() {$('[data-toggle=\"" + this.TooltipToggle + "\"]').tooltip();});</script>");
          output.Attributes.SetAttribute("title", (object) this.TooltipTitle);
        }
        output.Attributes.SetAttribute("data-toggle", (object) this.TooltipToggle);
      }
      else
        output.Content.AppendHtml("<div class=\"tooltip fade " + this.TooltipPlacement + " in static\" style=\"z-index:0;\" role=\"tooltip\"><div class=\"tooltip-arrow\"></div><div class=\"tooltip-inner\">" + content + "</div></div>");
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
