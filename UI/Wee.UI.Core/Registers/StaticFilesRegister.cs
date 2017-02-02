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
using Microsoft.AspNetCore.Builder;

namespace Wee.UI.Core.Registers
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed class StaticFilesRegister : BaseFileProvidersRegister, IWeeRegister<IApplicationBuilder>
    {
        private IApplicationBuilder _app;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="folderPath"></param>
        public StaticFilesRegister(IApplicationBuilder app, string folderPath)
            : base(folderPath)
        {
            _app = app;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IApplicationBuilder Invoke<T>()
            where T : class
        {
            var providers = base.LoadProviders<T>();

            if (providers.Count > 0)
            {
                    _app.UseStaticFiles(new StaticFileOptions
                    {
                        FileProvider = new CompositeFileProvider(providers)
                    });
            }

            return _app;
        }
    }
}
