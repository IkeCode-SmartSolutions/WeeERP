using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.DotNet.PlatformAbstractions;
using Wee.Common.Crypto;
using Microsoft.Extensions.DependencyModel;

namespace Wee.Common.Reflection
{
    public static class AssemblyTools
    {
        internal static readonly string[] _ignoredSystemAssemblies = { "System", "Microsoft", "Nuget", "mscorlib", "dotnet-", "Newtonsoft" };

        private static Dictionary<string, List<Assembly>> _assembliesCache { get; set; } = new Dictionary<string, List<Assembly>>();

        public static string GetDefaultNamespace(Assembly asm)
        {
            var attr = asm.GetCustomAttribute<DefaultNamespaceAttribute>();

            return attr != null ? attr.DefaultNamespace : string.Empty;
        }

        private static string GetCacheKey(string folderPath, bool ignoreSystemAssemblies = true, params string[] ignoredAssemblies)
        {
            var cacheKey = string.Empty;

            var ignoredString = string.Join(",", ignoredAssemblies);

            var result = $"{folderPath}_{ignoredAssemblies}_{ignoredString}";

            cacheKey = CryptoTools.CalculateMD5Hash(result);

            return cacheKey;
        }

        public static IEnumerable<Assembly> LoadAssemblies(string folderPath, bool ignoreSystemAssemblies = true, params string[] ignoredAssemblies)
        {
            var cacheKey = GetCacheKey(folderPath, ignoreSystemAssemblies, ignoredAssemblies);

            if (_assembliesCache.ContainsKey(cacheKey))
            {
                foreach (var cached in _assembliesCache[cacheKey])
                {
                    yield return cached;
                }
            }
            else
            {
                _assembliesCache[cacheKey] = new List<Assembly>();

                var runtimeId = RuntimeEnvironment.GetRuntimeIdentifier();
                var assemblieNames = DependencyContext.Default.GetRuntimeAssemblyNames(runtimeId);

                if (ignoreSystemAssemblies)
                {
                    assemblieNames = assemblieNames
                                    .Where(asm => _ignoredSystemAssemblies
                                                        .All(sysName => !asm.Name.StartsWith(sysName, StringComparison.CurrentCultureIgnoreCase))
                                          );
                }

                if (ignoredAssemblies.Length > 0)
                {
                    assemblieNames = assemblieNames
                                    .Where(asm => _ignoredSystemAssemblies
                                                        .All(sysName => !asm.Name.Equals(sysName, StringComparison.CurrentCultureIgnoreCase))
                                          );
                }

                if (assemblieNames.Count() == 0)
                    yield break;

                var asl = new AssemblyLoader(folderPath);

                foreach (var asmName in assemblieNames)
                {
                    var assembly = asl.LoadFromAssemblyName(asmName);

                    _assembliesCache[cacheKey].Add(assembly);

                    yield return assembly;
                }
            }
        }

        public static IEnumerable<Assembly> LoadAssembliesThatImplements<T>(string folderPath, bool ignoreSystemAssemblies = true, params string[] ignoredAssemblies)
        {
            var type = typeof(T);

            var result = new List<Assembly>();

            foreach (var asm in LoadAssemblies(folderPath, ignoreSystemAssemblies, ignoredAssemblies))
            {
                var moduleTypes = asm.GetTypes().Where(a => !a.GetTypeInfo().IsInterface
                                                             && type.IsAssignableFrom(a));

                var isAssignable = moduleTypes != null && moduleTypes.Count() > 0;

                if (!isAssignable)
                    continue;

                result.Add(asm);
            }

            return result;
        }

        public static IEnumerable<Type> LoadTypesThatImplements<T>(string folderPath)
        {
            var assemblies = LoadAssembliesThatImplements<T>(folderPath);

            return assemblies.LoadTypesThatImplements<T>();
        }

        public static IEnumerable<Type> LoadTypesThatImplements<T>(this IEnumerable<Assembly> assemblies)
        {
            var result = new List<Type>();

            foreach (var asm in assemblies)
            {
                var asmTypes = asm.LoadTypesThatImplements<T>();
                result.AddRange(asmTypes);
            }

            return result;
        }

        public static IEnumerable<Type> LoadTypesThatImplements<T>(this Assembly assembly)
        {
            var type = typeof(T);
            var result = assembly
                                .GetTypes()
                                .Where(i => !type.IsConstructedGenericType
                                         && type.IsAssignableFrom(i))
                                .ToList();
            return result;
        }

        public static IEnumerable<Type> LoadTypesThatImplementsGenericType(string folderPath, Type genericType)
        {
            var assemblies = LoadAssemblies(folderPath);

            return assemblies.LoadTypesThatImplementsGenericType(genericType);
        }

        public static IEnumerable<Type> LoadTypesThatImplementsGenericType(this IEnumerable<Assembly> assemblies, Type genericType)
        {
            var result = new List<Type>();

            var types = assemblies.SelectMany(i => i.GetTypes()).ToList();

            foreach (var asm in assemblies)
            {
                var asmTypes = asm.LoadTypesThatImplementsGenericType(genericType);
                result.AddRange(asmTypes);
            }

            return result;
        }

        public static IEnumerable<Type> LoadTypesThatImplementsGenericType(this Assembly assembly, Type genericType)
        {
            var result = assembly
                                .GetTypes()
                                .Where(t => t.GetTypeInfo().ImplementedInterfaces
                                                                .Where(i => i.IsConstructedGenericType
                                                                         && i.GetGenericTypeDefinition() == genericType).SingleOrDefault() != null
                                      ).ToList();
            return result;
        }

        public static T CreateInstance<T>(this Type type, params object[] args)
            where T : class
        {
            return type != null ? ((T)Activator.CreateInstance(type, args)) : null;
        }
    }
}
