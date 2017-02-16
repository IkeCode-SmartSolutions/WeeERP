using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wee.Common.Contracts;
using Microsoft.Extensions.FileProviders;
using Wee.Common.Reflection;
using Wee.Common;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Wee.UI.Core.Registers
{
    /// <summary>
    /// 
    /// </summary>
    internal abstract class BaseFileProvidersRegister<TExtensionReturnType> : IWeeRegister<TExtensionReturnType>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderPath"></param>
        public BaseFileProvidersRegister(string assembliesPath)
        {
            AssembliesPath = assembliesPath;
        }

        public string AssembliesPath { get; private set; }

        public abstract TExtensionReturnType Invoke<T>() 
            where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected List<IFileProvider> LoadProviders<T>()
        {
            var moduleAsms = AssemblyTools.LoadAssembliesThatImplements<T>(AssembliesPath);

            var providers = new List<IFileProvider>();

            var type = typeof(T);

            foreach (var moduleAsm in moduleAsms)
            {
                var ns = AssemblyTools.GetDefaultNamespace(moduleAsm);

                if (string.IsNullOrWhiteSpace(ns))
                {
                    var asmName = moduleAsm.GetName().Name;
                    throw new BaseComponentLoadException($"'{nameof(DefaultNamespaceAttribute)}' was not found on type {asmName}. Consider add attribute on {type.Name} class implementation (e.g. [assembly: DefaultNamespace(nameof({asmName}))])");
                }

                var embeddedFileProvider = new EmbeddedFileProvider(moduleAsm, ns);
                providers.Add(embeddedFileProvider);
            }

            return providers;
        }
    }
}
