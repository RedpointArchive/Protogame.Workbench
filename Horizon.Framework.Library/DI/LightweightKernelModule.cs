namespace Horizon.Framework
{
    public static class LightweightKernelModule
    {
        public static void BindCommon(this LightweightKernel kernel)
        {
            kernel.BindAndKeepInstance<IConfigManager, ConfigManager>();
            kernel.BindAndKeepInstance<IErrorLog, ErrorLog>();
            kernel.BindAndKeepInstance<RuntimeServer, RuntimeServer>();
            kernel.BindAndKeepInstance<IWorkflowManager, WorkflowManager>();
            kernel.BindAndKeepInstance<IAppHandlerManager, AppHandlerManager>();
            kernel.BindAndKeepInstance<IStartup, Startup>();
        }
    }
}