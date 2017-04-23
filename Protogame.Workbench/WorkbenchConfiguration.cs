using System.Collections.Generic;
using System.Threading.Tasks;
using Horizon.Framework;
using Protogame;
using Protogame.AppHandlers;
using Protogame.Workflows;

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
            return kernel.Get<WelcomeWorkflow>();
        }

        public void ConfigureAppHandlers(LightweightKernel kernel, Dictionary<string, IAppHandler> appHandlers)
        {
            appHandlers.Add("/welcome", kernel.Get<WelcomeAppHandler>());
            appHandlers.Add("/support", kernel.Get<SupportAppHandler>());
            appHandlers.Add("/learn", kernel.Get<LearnAppHandler>());
            appHandlers.Add("/open-docs", kernel.Get<OpenDocsAppHandler>());
            appHandlers.Add("/open-gitter", kernel.Get<OpenGitterAppHandler>());
            appHandlers.Add("/open-github", kernel.Get<OpenGitHubAppHandler>());
            appHandlers.Add("/open-twitter", kernel.Get<OpenTwitterAppHandler>());
        }

        public bool HandleSilentStartup(LightweightKernel kernel, string[] arguments)
        {
            return false;
        }

        public async Task PerformBackgroundWorkAtStartup(LightweightKernel kernel)
        {
            
        }

        public void GetWindowConfiguration(int displayWidth, int displayHeight, out int width, out int height, out bool allowResizing)
        {
            width = displayWidth / 2;
            height = (int)(displayHeight * 0.8f);
            allowResizing = true;
        }
    }
}
