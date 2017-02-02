using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Wee.UI.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-listgroup-item")]
  public class ListgroupItemTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string ListGroupItemClass { get; set; }

    [HtmlAttributeName("type")]
    public string ItemType { get; set; }

    [HtmlAttributeName("href")]
    public string ItemHref { get; set; }

    [HtmlAttributeName("class")]
    public string ItemTarget { get; set; }

    public ListgroupItemTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      string content = (await output.GetChildContentAsync()).GetContent();
      if (this.ItemType == "button")
        output.Content.AppendHtml("<button type=\"button\" class=\"list-group-item\"" + this.ListGroupItemClass + ">" + content + "</button>");
      else if (this.ItemHref.Length > 0)
      {
        output.Content.AppendHtml("<a href=" + this.ItemHref + " target=" + this.ItemTarget + "  class=\"list-group-item " + this.ListGroupItemClass + "\">" + content + "</a>");
      }
      else
      {
        output.Content.AppendHtml(content);
        output.Attributes.SetAttribute("class", (object) ("list-group-item " + this.ListGroupItemClass));
      }
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
