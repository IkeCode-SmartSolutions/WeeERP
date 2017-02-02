using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-dropdown-menu")]
  public class DropDownMenuTagHelper : TagHelper
  {
    [HtmlAttributeName("labelledby")]
    public string LabelledById { get; set; }

    [HtmlAttributeName("class")]
    public string DropDownMenuClass { get; set; }

    public DropDownMenuTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("dropdown-menu " + this.DropDownMenuClass));
      output.Attributes.SetAttribute("aria-labelledby", (object) this.LabelledById);
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
