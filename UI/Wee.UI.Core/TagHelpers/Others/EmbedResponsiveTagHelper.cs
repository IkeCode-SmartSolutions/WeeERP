using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("iframe", Attributes = "bootstrap-embed-responsive")]
  [HtmlTargetElement("object", Attributes = "bootstrap-embed-responsive")]
  [HtmlTargetElement("embed", Attributes = "bootstrap-embed-responsive")]
  [HtmlTargetElement("video", Attributes = "bootstrap-embed-responsive")]
  public class EmbedResponsiveTagHelper : TagHelper
  {
    [HtmlAttributeName("bootstrap-embed-responsive")]
    public string embedType { get; set; }

    [HtmlAttributeName("class")]
    public string EmbedClass { get; set; }

    public EmbedResponsiveTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.PreElement.AppendHtml("<bootstrap-embed-responsive class='embed-responsive embed-responsive-" + this.embedType + "'>");
      output.PostElement.AppendHtml("</bootstrap-embed-responsive>");
      output.Attributes.SetAttribute("class", (object) ("embed-responsive-item " + this.EmbedClass));
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
