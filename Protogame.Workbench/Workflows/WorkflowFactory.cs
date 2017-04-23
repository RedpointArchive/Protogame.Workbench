using Horizon.Framework;

namespace Protogame.Workflows
{
    public class WorkflowFactory : IWorkflowFactory
    {
        private readonly LightweightKernel _kernel;

        public WorkflowFactory(LightweightKernel kernel)
        {
            _kernel = kernel;
        }

        public IWorkflow CreateLearnWorkflow()
        {
            return new LearnWorkflow(_kernel.Get<RuntimeServer>());
        }

        public IWorkflow CreateSupportWorkflow()
        {
            return new SupportWorkflow(_kernel.Get<RuntimeServer>());
        }

        public IWorkflow CreateWelcomeWorkflow()
        {
            return new WelcomeWorkflow(_kernel.Get<RuntimeServer>());
        }
    }
}

