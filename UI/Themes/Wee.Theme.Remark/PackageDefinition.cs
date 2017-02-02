using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Wee.Common.Contracts;
using Wee.UI.Core.TagHelpers;
using Wee.Theme.Remark.TagHelpers;
using Wee.Common;

[assembly: DefaultNamespace("Wee.Theme.Remark")]
namespace Wee.Theme.Remark
{
    public class PackageDefinition : IWeeTheme
    {
        private readonly IServiceCollection _services;
        public PackageDefinition(IServiceCollection services)
        {
            _services = services;
        }

        public string Description { get { return "Remark theme description"; } }

        public string Name { get { return "Remark"; } }

        public int? Order
        {
            get
            {
                return 1;
            }
        }

        public void RegisterServices()
        {
            _services.AddTransient<IWeeOverrideTagHelper<ButtonTagHelper>, RemarkButtonTagHelper>();
        }
    }
}
