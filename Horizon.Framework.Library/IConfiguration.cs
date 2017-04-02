using System.Collections.Generic;
using System.Threading.Tasks;

namespace Horizon.Framework
{
    public interface IConfiguration
    {
        void ConfigureKernel(LightweightKernel kernel);

        bool HandleSilentStartup(LightweightKernel kernel, string[] arguments);

        Task PerformBackgroundWorkAtStartup(LightweightKernel kernel);

        IWorkflow GetInitialWorkflow(LightweightKernel kernel);

        void ConfigureAppHandlers(LightweightKernel kernel, Dictionary<string, IAppHandler> appHandlers);

        void GetWindowSize(out int width, out int height);
    }
}
