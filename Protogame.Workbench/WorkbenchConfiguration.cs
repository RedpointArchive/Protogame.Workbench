using System.Collections.Generic;
using System.Threading.Tasks;
using Horizon.Framework;
using Protogame;

[assembly: Configuration(typeof(WorkbenchConfiguration))]

namespace Protogame
{
    public class WorkbenchConfiguration : IConfiguration
    {
        public void ConfigureKernel(LightweightKernel kernel)
        {
            kernel.BindAndKeepInstance<IWorkflowFactory, WorkflowFactory>();
            kernel.BindAndKeepInstance<IBrandingEngine, WorkbenchBrandingEngine>();
        }

        public IWorkflow GetInitialWorkflow(LightweightKernel kernel)
        {
            return kernel.Get<InitialWorkflow>();
        }

        public void ConfigureAppHandlers(LightweightKernel kernel, Dictionary<string, IAppHandler> appHandlers)
        {
            /*

            _appHandlers.Add("/open-other", _kernel.Get<OpenOtherAppHandler>());
            _appHandlers.Add("/open-recent", _kernel.Get<OpenRecentAppHandler>());
            _appHandlers.Add("/create-new", _kernel.Get<CreateNewAppHandler>());
            _appHandlers.Add("/switch-platform", _kernel.Get<SwitchPlatformAppHandler>());
            _appHandlers.Add("/close", _kernel.Get<CloseProjectAppHandler>());
            _appHandlers.Add("/select-template", _kernel.Get<SelectTemplateAppHandler>());
            _appHandlers.Add("/cancel-creation", _kernel.Get<CancelCreationAppHandler>());
            _appHandlers.Add("/finalize-project", _kernel.Get<FinalizeProjectAppHandler>());
            _appHandlers.Add("/sync-projects", _kernel.Get<SyncProjectsAppHandler>());
            _appHandlers.Add("/resync-projects", _kernel.Get<ResyncProjectsAppHandler>());
            _appHandlers.Add("/generate-projects", _kernel.Get<GenerateProjectsAppHandler>());
            _appHandlers.Add("/create-package", _kernel.Get<CreatePackageAppHandler>());
            _appHandlers.Add("/automated-build", _kernel.Get<AutomatedBuildAppHandler>());
            _appHandlers.Add("/set-console-state", _kernel.Get<SetConsoleStateAppHandler>());
            _appHandlers.Add("/select-project-dir", _kernel.Get<SelectProjectDirAppHandler>());

            */
        }

        public void GetWindowSize(out int width, out int height)
        {
            width = 800;
            height = 600;
        }

        public bool HandleSilentStartup(LightweightKernel kernel, string[] arguments)
        {
            return false;
        }

        public async Task PerformBackgroundWorkAtStartup(LightweightKernel kernel)
        {
            
        }
    }
}
