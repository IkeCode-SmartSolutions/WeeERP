using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wee.Common.Contracts;

namespace Wee.UI.Core.Services
{
    public class MenuItem : IMenuItem
    {
        public string Parent { get; set; }
        public string ParentIcon { get; set; }
        public string Title { get; set; }
        public string Hint { get; set; }
        public int Order { get; set; }
        public string RouteName { get; set; }

        public string ControllerName
        {
            get
            {
                var split = RouteName.Split('#');
                if (split.Length > 1)
                {
                    return split[0].Replace("Controller", string.Empty).Substring(1);
                }
                else return "";
            }
        }

        public string ActionName
        {
            get
            {
                var split = RouteName.Split('#');
                if (split.Length > 1)
                {
                    return split[1];
                }
                else return "";
            }
        }

        public string Icon { get; set; }
        public List<IMenuItem> Children { get; set; }
        
        public MenuItem()
        {

        }

        public MenuItem(IMenuItem menu)
        {
            Parent = menu.Parent;
            ParentIcon = menu.ParentIcon;
            Title = menu.Title;
            Hint = menu.Hint;
            Order = menu.Order;
            RouteName = menu.RouteName;
            Icon = menu.Icon;
            Children = menu.Children;
        }

        private MenuItem(string parent, string parentIcon, string title, string hint, int order = 0, string icon = "")
        {
            Parent = parent;
            ParentIcon = parentIcon;
            Title = title;
            Hint = hint;
            Order = order;
            Icon = icon;
        }

        public MenuItem(string routeName, string parent, string parentIcon, string title, string hint, int order = 0, string icon = "")
            : this(parent, parentIcon, title, hint, order, icon)
        {
            RouteName = routeName;
        }

        public MenuItem(string controller, string action, string parent, string parentIcon, string title, string hint, int order = 0, string icon = "")
            : this(parent, parentIcon, title, hint, order, icon)
        {
            RouteName = $"${controller}#{action}";
        }
    }
}
