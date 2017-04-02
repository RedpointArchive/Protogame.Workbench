using System;
using Horizon.Framework;
using Protogame;

namespace Protogame
{
    public class WorkflowFactory : IWorkflowFactory
    {
        private readonly LightweightKernel m_Kernel;

        public WorkflowFactory(LightweightKernel kernel)
        {
            this.m_Kernel = kernel;
        }
       
        public IWorkflow CreateInitialWorkflow()
        {
            return new InitialWorkflow(
                this.m_Kernel.Get<RuntimeServer>(),
                this.m_Kernel.Get<IBrandingEngine>());
        }
    }
}

