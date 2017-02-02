using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-progress-bar")]
  public class ProgressBarTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string ProgressBarClass { get; set; }

    [HtmlAttributeName("value")]
    public string ProgressVal { get; set; }

    [HtmlAttributeName("valuemin")]
    public string ProgressValMin { get; set; }

    [HtmlAttributeName("valuemax")]
    public string ProgressValMax { get; set; }

    [HtmlAttributeName("minwidth")]
    public string ProgressMinWidth { get; set; }

    public ProgressBarTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      string content = (await output.GetChildContentAsync()).GetContent();
      string str = "";
      if (this.ProgressMinWidth.Length > 0)
        str = "min-width: " + this.ProgressMinWidth + ";";
      output.Content.AppendHtml(content);
      output.Attributes.SetAttribute("class", (object) ("progress-bar " + this.ProgressBarClass));
      output.Attributes.SetAttribute("style", (object) ("width: " + this.ProgressVal + "%; " + str));
      output.Attributes.SetAttribute("aria-valuenow", (object) this.ProgressVal);
      output.Attributes.SetAttribute("aria-valuemin", (object) this.ProgressValMin);
      output.Attributes.SetAttribute("aria-valuemax", (object) this.ProgressValMax);
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
