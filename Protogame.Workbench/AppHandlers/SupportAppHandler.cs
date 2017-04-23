using System;
using System.Collections.Specialized;
using Horizon.Framework;
using Protogame.Workflows;

namespace Protogame.AppHandlers
{
    public class SupportAppHandler : IAppHandler
    {
        private readonly IWorkflowFactory _workflowFactory;
        private readonly IWorkflowManager _workflowManager;

        public SupportAppHandler(
            IWorkflowFactory workflowFactory,
            IWorkflowManager workflowManager)
        {
            _workflowFactory = workflowFactory;
            _workflowManager = workflowManager;
        }

        public void Handle(NameValueCollection parameters)
        {
            _workflowManager.AppendWorkflow(_workflowFactory.CreateSupportWorkflow());
        }
    }
}
