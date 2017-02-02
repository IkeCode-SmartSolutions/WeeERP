using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-dropdown-menu-separator")]
  public class DropDownMenuSeparatorTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string DropDownSeparatorClass { get; set; }

    public DropDownMenuSeparatorTagHelper()
    {
      
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      output.Content.AppendHtml(string.Format("<div class='{0}'></div>", (object) this.DropDownSeparatorClass));
      output.Attributes.SetAttribute("role", (object) "dropdown-menu");
      output.Attributes.SetAttribute("class", (object) this.DropDownSeparatorClass);
      base.Process(context, output);
    }
  }
}
