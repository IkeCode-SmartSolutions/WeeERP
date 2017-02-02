using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Reflection;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Wee.UI.Core.TagHelpers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TBaseClass"></typeparam>
    public abstract class WeeTagHelper<TBaseClass> : TagHelper
        where TBaseClass : TagHelper
    {
        protected readonly IServiceProvider ServiceProvider;

        //protected readonly IAweOverrideTagHelper<TBaseClass> Overrider;

        public WeeTagHelper(IServiceProvider serviceProvider/*, IAweOverrideTagHelper<TBaseClass> overrider*/)
        {
            ServiceProvider = serviceProvider;
            //Overrider = overrider;
        }

        public abstract TBaseClass Self { get; }
        public abstract TagBuilder Builder { get; }

        public abstract Task ProcessAsync(TagBuilder builder, TagHelperContext context, TagHelperOutput output);

        public sealed override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await ProcessAsync(Builder, context, output);

            var customImplementations = ServiceProvider.GetServices<IWeeOverrideTagHelper<TBaseClass>>();

            if (customImplementations != null & customImplementations.Count() > 0)
            {
                foreach (var impl in customImplementations)
                {
                    impl.CustomProcess(Self, Builder, context, output);
                }
            }

            await base.ProcessAsync(context, output);
        }
    }
    
    /// <summary>
    /// A <see cref="ITagHelperActivator"/> that retrieves tag helpers as services from the request's
    /// <see cref="IServiceProvider"/>.
    /// </summary>
    public class WeeServiceBasedTagHelperActivator : ITagHelperActivator
    {
        /// <inheritdoc />
        public TTagHelper Create<TTagHelper>(ViewContext context) where TTagHelper : ITagHelper
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return context.HttpContext.RequestServices.GetRequiredService<TTagHelper>();
        }
    }

    /// <summary>
    /// Resolves tag helper types from the <see cref="ApplicationPartManager.ApplicationParts"/>
    /// of the application.
    /// </summary>
    public class WeeFeatureTagHelperTypeResolver : TagHelperTypeResolver
    {
        private readonly TagHelperFeature _feature;

        /// <summary>
        /// Initializes a new <see cref="FeatureTagHelperTypeResolver"/> instance.
        /// </summary>
        /// <param name="manager">The <see cref="ApplicationPartManager"/> of the application.</param>
        public WeeFeatureTagHelperTypeResolver(ApplicationPartManager manager)
        {
            if (manager == null)
            {
                throw new ArgumentNullException(nameof(manager));
            }

            _feature = new TagHelperFeature();
            manager.PopulateFeature(_feature);
        }

        /// <inheritdoc />
        protected override IEnumerable<TypeInfo> GetExportedTypes(AssemblyName assemblyName)
        {
            if (assemblyName == null)
            {
                throw new ArgumentNullException(nameof(assemblyName));
            }

            var results = new List<TypeInfo>();
            for (var i = 0; i < _feature.TagHelpers.Count; i++)
            {
                var tagHelperAssemblyName = _feature.TagHelpers[i].Assembly.GetName();

                if (AssemblyNameComparer.OrdinalIgnoreCase.Equals(tagHelperAssemblyName, assemblyName))
                {
                    results.Add(_feature.TagHelpers[i]);
                }
            }

            return results;
        }

        /// <inheritdoc />
        protected sealed override bool IsTagHelper(TypeInfo typeInfo)
        {
            // Return true always as we have already decided what types are tag helpers when GetExportedTypes
            // gets called.
            return true;
        }

        private class AssemblyNameComparer : IEqualityComparer<AssemblyName>
        {
            public static readonly IEqualityComparer<AssemblyName> OrdinalIgnoreCase = new AssemblyNameComparer();

            private AssemblyNameComparer()
            {
            }

            public bool Equals(AssemblyName x, AssemblyName y)
            {
                // Ignore case because that's what Assembly.Load does.
                return string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.CultureName ?? string.Empty, y.CultureName ?? string.Empty, StringComparison.Ordinal);
            }

            public int GetHashCode(AssemblyName obj)
            {
                var hashCode = 0;
                if (obj.Name != null)
                {
                    hashCode ^= obj.Name.GetHashCode();
                }

                hashCode ^= (obj.CultureName ?? string.Empty).GetHashCode();
                return hashCode;
            }
        }
    }

    public static class WeeTagHelpersAsServices
    {
        public static void AddTagHelpersAsServices(ApplicationPartManager manager, IServiceCollection services)
        {
            if (manager == null)
            {
                throw new ArgumentNullException(nameof(manager));
            }

            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var feature = new TagHelperFeature();
            manager.PopulateFeature(feature);

            foreach (var type in feature.TagHelpers.Select(t => t.AsType()))
            {
                services.TryAddTransient(type, type);
            }

            services.Replace(ServiceDescriptor.Transient<ITagHelperActivator, WeeServiceBasedTagHelperActivator>());
            services.Replace(ServiceDescriptor.Transient<ITagHelperTypeResolver, WeeFeatureTagHelperTypeResolver>());
        }
    }
}
