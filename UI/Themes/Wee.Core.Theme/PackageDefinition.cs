using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Wee.Common.Contracts;
using Wee.Common;

[assembly: DefaultNamespace("Wee.Core.Theme")]
namespace Wee.Core.Theme
{
    public class PackageDefinition : IWeeTheme
    {
        private readonly IServiceCollection _services;
        public PackageDefinition(IServiceCollection services)
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
        }
    }
}
