using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Wee.UI.Core.TagHelpers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TBaseClass"></typeparam>
    public interface IWeeTagHelper<TBaseClass>
        where TBaseClass : TagHelper
    {
        
    }
}
