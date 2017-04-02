using System;

namespace Horizon.Framework
{
    public interface IWorkflowManager
    {
        void AppendWorkflow(IWorkflow workflow);

        void Start();
    }
}

