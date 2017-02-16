using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Wee.Common.Contracts;
using Wee.UI.Core.TagHelpers;
using Wee.Common;

[assembly: DefaultNamespace("Wee.Auth.Module")]
namespace Wee.Auth.Module
{
    public class ModuleDefinition : IWeeModule
    {
        private readonly IServiceCollection _services;
        public ModuleDefinition(IServiceCollection services)
        {
            _services = services;
        }

        public string Description { get { return "Authentication Module description"; } }

        public string Name { get { return "Wee Authentication Module"; } }

        public int? Order
        {
            get
            {
                return 100;
            }
        }

        public string RootMenuDefaultTitle
        {
            get
            {
                return "Controle de Acesso";
            }
        }

        public void RegisterServices()
        {
            
        }
    }
}
