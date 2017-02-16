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
    internal sealed class MvcRegister : IWeeRegister<IMvcBuilder>
    {
        private readonly IMvcBuilder _mvcBuilder;
        public string AssembliesPath { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="assembliesPath"></param>
        public MvcRegister(IMvcBuilder mvcBuilder, string assembliesPath)
        {
            _mvcBuilder = mvcBuilder;
            AssembliesPath = assembliesPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IMvcBuilder Invoke<T>()
            where T : class
        {
            var moduleAsms = AssemblyTools.LoadAssembliesThatImplements<T>(AssembliesPath);

            foreach (var asm in moduleAsms)
            {
                _mvcBuilder.AddApplicationPart(asm);
            }

            _mvcBuilder.AddControllersAsServices();

            return _mvcBuilder;
        }
    }
}
