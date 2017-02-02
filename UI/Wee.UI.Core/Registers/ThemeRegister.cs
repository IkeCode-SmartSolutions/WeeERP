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
    internal sealed class ThemeRegister : IWeeRegister<IServiceCollection>
    {
        private IServiceCollection _serviceCollection;
        private string _folderPath;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="folderPath"></param>
        public ThemeRegister(IServiceCollection serviceCollection, string folderPath)
        {
            _serviceCollection = serviceCollection;
            _folderPath = folderPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IServiceCollection Invoke<T>()
            where T : class
        {
            var types = AssemblyTools.LoadTypesThatImplements<T>(_folderPath);

            var ctorTypes = new Type[] { typeof(IServiceCollection) };
            var packageType = typeof(IWeePackage);
            foreach (var type in types)
            {
                object[] args = new object[0];

                var isServiceCollectionConstructor = type.GetConstructor(ctorTypes) != null;

                if (isServiceCollectionConstructor)
                {
                    args = new object[] { _serviceCollection };
                }

                var instance = type.CreateInstance<T>(args);
                if (packageType.IsAssignableFrom(instance.GetType()))
                    (instance as IWeePackage)?.RegisterServices();
            }

            return _serviceCollection;
        }
    }
}
