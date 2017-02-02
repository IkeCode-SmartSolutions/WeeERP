using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wee.Common.Contracts
{
    public interface IMenuService
    {
        Dictionary<IMenuCategory, List<IMenuItem>> RegisteredMenus { get; }

        void RegisterMenu(int categoryOrder, string categoryName, IMenuItem menu);

        void RegisterMenu(IMenuCategory category, IMenuItem menu);

        Dictionary<string, List<IMenuItem>> BuildMenu();
    }
}
