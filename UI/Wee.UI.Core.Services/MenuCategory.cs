using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wee.Common.Contracts;

namespace Wee.UI.Core.Services
{
    public class MenuCategory : IMenuCategory
    {
        public string Title { get; private set; }
        public int Order { get; private set; }

        public MenuCategory(MenuCategory menuCategory)
        {
            Title = menuCategory.Title;
            Order = menuCategory.Order;
        }

        public MenuCategory(int order, string title)
        {
            title = title == null ? "Outros" : title;

            Title = title;
            Order = order;
        }

        public override int GetHashCode()
        {
            return ($"{this.Order}{this.Title}").GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var o = obj as MenuCategory;

            return o.Order == this.Order && o.Title.Equals(this.Title, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
