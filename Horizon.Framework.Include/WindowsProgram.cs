using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#if PLATFORM_WINDOWS
namespace Horizon.Framework
{
    using System;
    using System.Diagnostics;

    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            if (Debugger.IsAttached)
            {
                Run(args);
            }
            else
            {
                // TODO: Crash Reporting

                try
                {
                    Run(args);
                }
                catch (Exception e)
                {
                    lock (WindowsUIManager.SubmissionLock)
                    {
                        if (WindowsUIManager.IsSubmitting)
                        {
                            return;
                        }

                        WindowsUIManager.IsSubmitting = true;
                    }

                    // TODO: Crash Reporting
                }
            }
        }

        public static void Run(string[] args)
        {
            var kernel = new LightweightKernel();
            kernel.BindCommon();
            kernel.BindAndKeepInstance<IUIManager, WindowsUIManager>();
            kernel.BindAndKeepInstance<IExecution, WindowsExecution>();
            
            Func<System.Reflection.Assembly, Type[]> TryGetTypes = assembly =>
            {
                try
                {
                    return assembly.GetTypes();
                }
                catch
                {
                    return new Type[0];
                }
            };
            
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var typeSource = new List<Type>();
            foreach (var assembly in assemblies)
            {
                typeSource.AddRange(assembly.GetCustomAttributes<ConfigurationAttribute>().Select(x => x.Type));
            }

            if (typeSource.Count == 0)
            {
                // Scan all types to find implementors of IGameConfiguration
                typeSource.AddRange(from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                    from type in TryGetTypes(assembly)
                                    select type);
            }
            
            var configurations = new List<IConfiguration>();
            foreach (var type in typeSource)
            {
                if (typeof(IConfiguration).IsAssignableFrom(type) &&
                    !type.IsInterface && !type.IsAbstract)
                {
                    configurations.Add(Activator.CreateInstance(type) as IConfiguration);
                }
            }

            var configuration = configurations.First();
            kernel.BindAndKeepInstance(typeof(IConfiguration), configuration.GetType());
            configuration.ConfigureKernel(kernel);

            kernel.Get<IErrorLog>().Log("Started Protobuild Manager on Windows platform");

            var startup = kernel.Get<IStartup>();
            startup.Start(args);
        }
    }
}
#endif

