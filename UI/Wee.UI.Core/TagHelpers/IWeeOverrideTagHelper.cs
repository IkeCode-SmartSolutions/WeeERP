using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Wee.UI.Core.TagHelpers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TBaseClass"></typeparam>
    public interface IWeeOverrideTagHelper<TBaseClass> : IWeeTagHelper<TBaseClass>
        where TBaseClass : TagHelper
    {
        void CustomProcess(TBaseClass baseClassInstance, TagBuilder builder, TagHelperContext context, TagHelperOutput output);
    }
}
