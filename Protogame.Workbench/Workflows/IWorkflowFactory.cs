using System;
using Horizon.Framework;

namespace Protogame
{
    public interface IWorkflowFactory
    {
        IWorkflow CreateInitialWorkflow();
    }
}

