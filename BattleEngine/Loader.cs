using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BattleEngine
{
    public static class Loader
    {
        private static readonly DirectoryInfo AssemblyDirectory 
            = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory;
        
        public static IEnumerable<T> GetEnumerableOfType<T>(IEnumerable<Assembly> assemblies, 
            params object[] constructorArgs) where T : class
        {
            return assemblies.SelectMany(a => a.GetTypes()).Distinct()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(T)))
                .Select(t => Activator.CreateInstance(t, constructorArgs)).Cast<T>().ToArray();
        }

        public static IEnumerable<T> GetTypesFromLocalAssemblies<T>(params object[] constructorArgs) where T : class
        {
            var assemblies = AssemblyDirectory.GetFiles("*.dll")
                .Select(f => Assembly.LoadFile(f.FullName))
                .Union(AppDomain.CurrentDomain.GetAssemblies()).Distinct();
            return GetEnumerableOfType<T>(assemblies, constructorArgs);
        }

        public static IEnumerable<Unit> GetUnits() => GetTypesFromLocalAssemblies<Unit>();
    }
}