using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wee.Common.Contracts;
using Wee.Common.Reflection;
using System.Reflection;
using Wee.Common;
using Wee.UI.Core.Services;

namespace Wee.UI.Core.Registers
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed class MenuRegister : IWeeRegister<IApplicationBuilder>
    {
        private readonly IApplicationBuilder _appBuilder;
        public string AssembliesPath { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appBuilder"></param>
        /// <param name="assembliesPath"></param>
        public MenuRegister(IApplicationBuilder appBuilder, string assembliesPath)
        {
            _appBuilder = appBuilder;
            AssembliesPath = assembliesPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IApplicationBuilder Invoke<T>()
            where T : class
        {
            var menuService = _appBuilder.ApplicationServices.GetService<IMenuService>();

            if (menuService != null)
            {
                var asms = AssemblyTools.LoadAssembliesThatImplements<T>(AssembliesPath);
                var t = typeof(Controller);
                var tMethod = typeof(IActionResult);
                var tModule = typeof(IWeeModule);
                var ctorTypes = new Type[] { typeof(IServiceCollection) };

                foreach (var asm in asms)
                {
                    var moduleType = asm.GetTypes().FirstOrDefault(i => !i.GetTypeInfo().IsInterface && tModule.IsAssignableFrom(i));
                    
                    if (moduleType != null)
                    {
                        object[] args = new object[0];

                        var isServiceCollectionConstructor = moduleType.GetConstructor(ctorTypes) != null;

                        if (isServiceCollectionConstructor)
                        {
                            args = new object[] { null };
                        }
                        
                        var module = AssemblyTools.CreateInstance<IWeeModule>(moduleType, args);

                        var rootMenuDefaultTitle = module?.RootMenuDefaultTitle;

                        var controllers = asm.GetTypes().Where(i => !i.GetTypeInfo().IsInterface
                                                                    && t.IsAssignableFrom(i))
                                                        .ToList();

                        foreach (var controller in controllers)
                        {
                            var methods = controller.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                                                    .Where(m => !m.IsVirtual
                                                                && tMethod.IsAssignableFrom(m.ReturnType)
                                                                && m.GetCustomAttribute<MenuAttribute>() != null)
                                                    .ToList();

                            foreach (var method in methods)
                            {
                                var menuAttr = method.GetCustomAttribute<MenuAttribute>();
                                var routeAttr = method.GetCustomAttribute<RouteAttribute>();

                                IMenuItem menu;

                                var category = string.IsNullOrWhiteSpace(rootMenuDefaultTitle) ? menuAttr.Category : rootMenuDefaultTitle;

                                if (routeAttr == null)
                                {
                                    menu = new MenuItem(controller.Name, method.Name, menuAttr.Parent, menuAttr.ParentIcon, menuAttr.Title, menuAttr.Hint, menuAttr.Order, menuAttr.Icon);
                                }
                                else
                                {
                                    menu = new MenuItem(routeAttr.Name, menuAttr.Parent, menuAttr.ParentIcon, menuAttr.Title, menuAttr.Hint, menuAttr.Order, menuAttr.Icon);
                                }

                                var categoryOrder = module?.Order ?? menuAttr.CategoryOrder ?? 9999;

                                menuService.RegisterMenu(categoryOrder, category, menu);
                            }
                        }
                    }
                }
            }

            return _appBuilder;
        }
    }
}
