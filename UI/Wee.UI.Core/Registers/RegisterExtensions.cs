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
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public static IApplicationBuilder WeeRegisterPackages(this IApplicationBuilder app, string folderPath = "")
        {
            if (string.IsNullOrWhiteSpace(folderPath))
                folderPath = PlatformServices.Default.Application.ApplicationBasePath;

            var instance = new StaticFilesRegister(app, folderPath);            
            instance.Invoke<IWeePackage>();

            var menuInstance = new MenuRegister(app, folderPath);
            menuInstance.Invoke<Controller>();

            return app;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public static IServiceCollection WeeRegisterPackages(this IServiceCollection services, string folderPath = "")
        {
            if (string.IsNullOrWhiteSpace(folderPath))
                folderPath = PlatformServices.Default.Application.ApplicationBasePath;

            var razorViewInstance = new RazorViewFileProvidersRegister(services, folderPath);
            razorViewInstance.Invoke<IWeePackage>();

            var themeInstance = new ThemeRegister(services, folderPath);
            themeInstance.Invoke<IWeePackage>();

            return services;
        }
    }
}
