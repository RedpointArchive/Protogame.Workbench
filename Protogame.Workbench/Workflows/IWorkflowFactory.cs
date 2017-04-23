using System;
using Horizon.Framework;

namespace Protogame.Workflows
{
    public interface IWorkflowFactory
    {
        IWorkflow CreateWelcomeWorkflow();

        IWorkflow CreateLearnWorkflow();

        IWorkflow CreateSupportWorkflow();
    }
}

