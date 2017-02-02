using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wee.Common.Contracts;

namespace Wee.UI.Core.Services
{
    public class MenuService : IMenuService
    {
        public Dictionary<IMenuCategory, List<IMenuItem>> RegisteredMenus { get; private set; } = new Dictionary<IMenuCategory, List<IMenuItem>>();

        public void RegisterMenu(int categoryOrder, string categoryName, IMenuItem menu)
        {
            var category = new MenuCategory(categoryOrder, categoryName);

            RegisterMenu(category, menu);
        }

        public void RegisterMenu(IMenuCategory menuCategory, IMenuItem menu)
        {
            if (RegisteredMenus.ContainsKey(menuCategory))
            {
                RegisteredMenus[menuCategory].Add(menu);
            }
            else
            {
                var newMenu = new List<IMenuItem>() { menu };
                RegisteredMenus[menuCategory] = newMenu;
            }

            //Adiciona os parents como item de menu, é apenas um "holder" pros filhos e evita de ter que criar [MenuAttribute] só pra isso.
            if (!string.IsNullOrWhiteSpace(menu.Parent) && !RegisteredMenus[menuCategory].Any(i => i.Title == menu.Parent))
            {
                RegisteredMenus[menuCategory].Add(new MenuItem() { Title = menu.Parent, ParentIcon = menu.ParentIcon });
            }
        }

        public Dictionary<string, List<IMenuItem>> BuildMenu()
        {
            var result = new Dictionary<string, List<IMenuItem>>();

            var ordered = RegisteredMenus.OrderBy(i => i.Key.Order).ToDictionary(i => i.Key.Title, i => i.Value);

            foreach (var registeredMenu in ordered)
            {
                var tree = RecursiveMenu(null, registeredMenu.Value);

                result.Add(registeredMenu.Key, tree);
            }

            return result;
        }

        private List<IMenuItem> RecursiveMenu(string parent, List<IMenuItem> source)
        {
            var filtered = source.Where(i => i.Parent == parent).ToList();

            var recursive = from menu in filtered
                    select new MenuItem(menu)
                    {
                        Children = RecursiveMenu(menu.Title, source)
                    };

            return recursive.ToList<IMenuItem>();
        }
    }
}
