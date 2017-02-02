using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Wee.UI.Core.TagHelpers;

namespace Wee.Theme.Remark.TagHelpers
{
    /// <summary>
    /// 
    /// </summary>
    [HtmlTargetElement("bootstrap-button")]
    public class RemarkButtonTagHelper : IWeeOverrideTagHelper<ButtonTagHelper>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceProvider">Injected IServiceProvider</param>
        public RemarkButtonTagHelper(IServiceProvider serviceProvider) 
            : base()
        {
        }

        /// <summary>
        /// Custom implementation
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public async void CustomProcess(ButtonTagHelper baseClassInstance, TagBuilder builder, TagHelperContext context, TagHelperOutput output)
        {
            builder.MergeAttribute("data-custommerge", "true");

            builder.Attributes.Add("data-customadd", "true");

            var childContent = output.Content.IsModified ? output.Content.GetContent() : (await output.GetChildContentAsync()).GetContent();
        }
    }
}
