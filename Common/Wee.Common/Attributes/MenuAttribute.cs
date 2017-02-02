using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wee.Common
{
    public class MenuAttribute : Attribute
    {
        private string _category;
        private int? _categoryOrder;
        private string _parent;
        private string _title;
        private int _order;
        private string _icon;
        private string _hint;

        /// <summary>
        /// Configure a menu to be automatically loaded on application start.
        /// It's try to get Menu Category Title from IAweModule.MenuCategoryTitle 
        /// </summary>
        /// <param name="parent">Parent menu key</param>
        /// <param name="title">Displayed title</param>
        /// <param name="hint">Help text on mouse over, if null or empty assumes Title</param>
        /// <param name="order">Position on related parent children list</param>
        /// <param name="icon">Menu icon</param>
        public MenuAttribute(string parent, string title, string hint = "", int order = 0, string icon = "")
        {
            _parent = parent;
            _title = title;
            _order = order;
            _icon = icon;
            _hint = string.IsNullOrWhiteSpace(hint) ? title : hint;
        }

        /// <summary>
        /// Configure a menu to be automatically loaded on application start.
        /// </summary>
        /// <param name="category">Menu Category key</param>
        /// <param name="parent">Parent menu key</param>
        /// <param name="title">Displayed title</param>
        /// <param name="hint">Help text on mouse over, if null or empty assumes Title</param>
        /// <param name="order">Position on related parent children list</param>
        /// <param name="icon">Menu icon</param>
        public MenuAttribute(string category, int categoryOrder, string parent, string title, string hint = "", int order = 0, string icon = "")
            : this(parent, title, hint, order, icon)
        {
            _category = category;
            _categoryOrder = categoryOrder;
        }

        public string Category { get { return _category; } }

        public int? CategoryOrder { get { return _categoryOrder; } }

        public string Parent { get { return _parent; } }

        public string Title { get { return _title; } }

        public int Order { get { return _order; } }

        public string Icon { get { return _icon; } }

        public string Hint { get { return _hint; } }
    }
}
