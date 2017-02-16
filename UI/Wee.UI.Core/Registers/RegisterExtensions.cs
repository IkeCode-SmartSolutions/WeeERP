using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Wee.UI.Core.Registers;
using Wee.Common.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Wee.UI.Core
{
    /// <summary>
    /// 
    /// </summary>
    public static class RegisterExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="assembliesPath"></param>
        /// <returns></returns>
        public static IApplicationBuilder WeePackagesRegister(this IApplicationBuilder app, string assembliesPath = "")
        {
            if (string.IsNullOrWhiteSpace(assembliesPath))
                assembliesPath = PlatformServices.Default.Application.ApplicationBasePath;

            var instance = new StaticFilesRegister(app, assembliesPath);            
            instance.Invoke<IWeePackage>();

            var menuInstance = new MenuRegister(app, assembliesPath);
            menuInstance.Invoke<Controller>();

            return app;
        }

        public static IMvcBuilder WeePackagesRegister(this IMvcBuilder mvcBuilder, string assembliesPath = "")
        {
            if (string.IsNullOrWhiteSpace(assembliesPath))
                assembliesPath = PlatformServices.Default.Application.ApplicationBasePath;

            var razorViewInstance = new MvcRegister(mvcBuilder, assembliesPath);
            razorViewInstance.Invoke<IWeePackage>();

            return mvcBuilder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assembliesPath"></param>
        /// <returns></returns>
        public static IServiceCollection WeePackagesRegister(this IServiceCollection services, string assembliesPath = "")
        {
            if (string.IsNullOrWhiteSpace(assembliesPath))
                assembliesPath = PlatformServices.Default.Application.ApplicationBasePath;

            services.WeeRegisterRegisters();

            var razorViewInstance = new RazorViewFileProvidersRegister(services, assembliesPath);
            razorViewInstance.Invoke<IWeePackage>();

            var themeInstance = new PackageServicesRegister(services, assembliesPath);
            themeInstance.Invoke<IWeePackage>();
            
            services
                .AddMvc()
                .WeePackagesRegister();

            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        private static IServiceCollection WeeRegisterRegisters(this IServiceCollection services)
        {
            var assembliesPath = PlatformServices.Default.Application.ApplicationBasePath;
            
            var types = Common.Reflection.AssemblyTools.LoadTypesThatImplements<IWeePackage>(assembliesPath, null
                                );
            foreach (var t in types)
            {
                services.AddSingleton(t, t);
            }

            return services;
        }
    }
}
