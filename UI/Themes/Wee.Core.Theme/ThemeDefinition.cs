using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Wee.Common.Contracts;
using Wee.Common;
using Wee.UI.Core.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

[assembly: DefaultNamespace("Wee.Core.Theme")]
namespace Wee.Core.Theme
{
    public class ThemeDefinition : IWeeTheme
    {
        private readonly IServiceCollection _services;
        public ThemeDefinition(IServiceCollection services)
        {
            _services = services;
        }

        public string Description { get { return "Core theme description"; } }

        public string Name { get { return "Core Theme"; } }

        public int? Order
        {
            get
            {
                return 0;
            }
        }

        public void RegisterServices()
        {
            _services.TryAddSingleton<IMenuService, MenuService>();
        }
    }
}
