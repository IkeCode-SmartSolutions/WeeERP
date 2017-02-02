using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-jumbotron")]
  public class JumbotronTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string JumbotronClass { get; set; }

    public JumbotronTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("class", (object) ("jumbotron " + this.JumbotronClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
