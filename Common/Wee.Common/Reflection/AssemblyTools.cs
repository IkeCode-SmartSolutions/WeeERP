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

        private static string GetCacheKey(string assembliesPath, bool ignoreSystemAssemblies = true, params string[] ignoredAssemblies)
        {
            var cacheKey = string.Empty;

            var ignoredString = ignoredAssemblies != null ? string.Join(",", ignoredAssemblies) : "";

            var result = $"{assembliesPath}_{ignoreSystemAssemblies}_{ignoredString}";

            cacheKey = CryptoTools.CalculateMD5Hash(result);

            return cacheKey;
        }

        private static List<Assembly> AssembliesLoader(string assembliesPath, string cacheKey, IEnumerable<AssemblyName> assemblyNames)
        {
            var result = new List<Assembly>();

            var asl = new AssemblyLoader(assembliesPath);

            foreach (var asmName in assemblyNames)
            {
                var assembly = asl.LoadFromAssemblyName(asmName);

                result.Add(assembly);
            }

            _assembliesCache[cacheKey] = result;

            return result;
        }

        public static List<Assembly> LoadAssemblies(string assembliesPath, Func<AssemblyName, bool> predicate = null, bool ignoreSystemAssemblies = true, params string[] ignoredAssemblies)
        {
            var cacheKey = GetCacheKey(assembliesPath, ignoreSystemAssemblies, ignoredAssemblies);
            var result = new List<Assembly>();

            if (_assembliesCache.ContainsKey(cacheKey))
            {
                return _assembliesCache[cacheKey];
            }
            else
            {
                _assembliesCache[cacheKey] = new List<Assembly>();

                var runtimeId = RuntimeEnvironment.GetRuntimeIdentifier();
                var assemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(runtimeId);

                if (ignoreSystemAssemblies)
                {
                    assemblyNames = assemblyNames
                                    .Where(asm => _ignoredSystemAssemblies
                                                        .All(sysName => !asm.Name.StartsWith(sysName, StringComparison.OrdinalIgnoreCase))
                                          );
                }

                if (ignoredAssemblies?.Length > 0)
                {
                    assemblyNames = assemblyNames
                                    .Where(asm => _ignoredSystemAssemblies
                                                        .All(sysName => !asm.Name.Equals(sysName, StringComparison.OrdinalIgnoreCase))
                                          );
                }

                if (predicate != null)
                {
                    assemblyNames = assemblyNames.Where(predicate);
                }

                if (assemblyNames.Count() == 0)
                    return result;

                result = AssembliesLoader(assembliesPath, cacheKey, assemblyNames);
            }
            return result;
        }

        public static IEnumerable<Assembly> LoadAssembliesThatImplements<T>(string assembliesPath,
                                                                            Func<AssemblyName, bool> assembliesPredicate = null,
                                                                            bool ignoreSystemAssemblies = true,
                                                                            string[] ignoredAssemblies = null,
                                                                            Func<Type, bool> typesPredicate = null)
        {
            var type = typeof(T);

            var result = new List<Assembly>();

            var assemblies = LoadAssemblies(assembliesPath, assembliesPredicate, ignoreSystemAssemblies, ignoredAssemblies);

            var p = (new List<Func<Type, bool>>(typesPredicate) { i => !i.GetTypeInfo().IsInterface && type.IsAssignableFrom(i) }).ToArray();

            foreach (var asm in assemblies)
            {
                var moduleTypes = asm.LoadTypesThatImplements<T>(p);

                var isAssignable = moduleTypes != null && moduleTypes.Count() > 0;

                if (!isAssignable)
                    continue;

                result.Add(asm);
            }

            return result;
        }

        public static IEnumerable<Type> LoadTypesThatImplements<T>(string assembliesPath,
                                                                   Func<AssemblyName, bool> assembliesPredicate = null,
                                                                   bool ignoreSystemAssemblies = true,
                                                                   string[] ignoredAssemblies = null,
                                                                   params Func<Type, bool>[] typesPredicate)
        {
            var assemblies = LoadAssembliesThatImplements<T>(assembliesPath, assembliesPredicate, ignoreSystemAssemblies, ignoredAssemblies, typesPredicate);
            
            return assemblies.LoadTypesThatImplements<T>(typesPredicate);
        }

        public static IEnumerable<Type> LoadTypesThatImplements<T>(this IEnumerable<Assembly> assemblies,
                                                                   params Func<Type, bool>[] predicates)
        {
            var result = new List<Type>();
            var type = typeof(T);

            foreach (var asm in assemblies)
            {
                var asmTypes = asm.LoadTypesThatImplements<T>(predicates);
                result.AddRange(asmTypes);
            }

            return result;
        }

        public static IEnumerable<Type> LoadTypesThatImplements<T>(this Assembly assembly,
                                                                   params Func<Type, bool>[] predicates)
        {
            return LoadTypesThatImplements(assembly, typeof(T), predicates);
        }

        public static IEnumerable<Type> LoadTypesThatImplements(this Assembly assembly,
                                                                Type type,
                                                                params Func<Type, bool>[] predicates)
        {
            List<Type> result = new List<Type>();
            var allTypes = assembly.GetTypes();

            var p = (new List<Func<Type, bool>>(predicates) { i => !type.IsConstructedGenericType && type.IsAssignableFrom(i) }).ToArray();

            foreach (var predicate in p)
            {
                var filtered = allTypes.Where(predicate);
                result.AddRange(filtered);
            }
            
            return result;
        }

        public static IEnumerable<Type> LoadTypesThatImplementsGenericType(string assembliesPath, Type genericType, params Func<Type, bool>[] predicates)
        {
            var assemblies = LoadAssemblies(assembliesPath);

            return assemblies.LoadTypesThatImplementsGenericType(genericType, predicates);
        }

        public static IEnumerable<Type> LoadTypesThatImplementsGenericType(this IEnumerable<Assembly> assemblies, Type genericType, params Func<Type, bool>[] predicates)
        {
            var result = new List<Type>();

            foreach (var asm in assemblies)
            {
                var asmTypes = asm.LoadTypesThatImplementsGenericType(genericType, predicates);
                result.AddRange(asmTypes);
            }

            return result;
        }

        public static IEnumerable<Type> LoadTypesThatImplementsGenericType(this Assembly assembly, Type genericType, params Func<Type, bool>[] predicates)
        {
            var result = assembly
                                .GetTypes().ToList();

            var p = (new List<Func<Type, bool>>(predicates) { t => t.GetTypeInfo().ImplementedInterfaces
                                                                .Where(i => i.IsConstructedGenericType
                                                                         && i.GetGenericTypeDefinition() == genericType).SingleOrDefault() != null }).ToArray();

            foreach (var predicate in p)
            {
                result.Where(predicate);
            }

            return result;
        }

        public static T CreateInstance<T>(this Type type, params object[] args)
            where T : class
        {
            return type != null ? ((T)Activator.CreateInstance(type, args)) : null;
        }
    }
}
