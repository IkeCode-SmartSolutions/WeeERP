using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wee.Common.Reflection;
using System.Reflection;
using Wee.Common.Contracts;

namespace Wee.UI.Core.Registers
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed class PackageServicesRegister : IWeeRegister<IServiceCollection>
    {
        private readonly IServiceCollection _serviceCollection;
        public string AssembliesPath { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="assembliesPath"></param>
        public PackageServicesRegister(IServiceCollection serviceCollection, string assembliesPath)
        {
            _serviceCollection = serviceCollection;
            AssembliesPath = assembliesPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IServiceCollection Invoke<T>()
            where T : class
        {
            var types = AssemblyTools.LoadTypesThatImplements<T>(AssembliesPath);

            var ctorTypes = new Type[] { typeof(IServiceCollection) };
            var packageType = typeof(IWeePackage);
            foreach (var type in types)
            {
                object[] args = new object[0];

                var isServiceCollectionConstructor = type.GetConstructor(ctorTypes) != null;

                if (isServiceCollectionConstructor)
                {
                    args = new object[] { _serviceCollection };

                    var instance = type.CreateInstance<T>(args);
                    if (packageType.IsAssignableFrom(instance.GetType()))
                        (instance as IWeePackage)?.RegisterServices();
                }
                else
                {
                    throw new NotSupportedException("IWeePackage implementations must to have a constructor with IServiceCollection parameter. (e.g. ctor(IServiceCollection serviceCollection) {...} )");
                }
            }

            return _serviceCollection;
        }
    }
}
