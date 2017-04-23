using System;
using Horizon.Framework;

namespace Protogame.Workflows
{
    public class SupportWorkflow : IWorkflow
    {
        private readonly RuntimeServer _runtimeServer;

        public SupportWorkflow(RuntimeServer runtimeServer)
        {
            _runtimeServer = runtimeServer;
        }

        public void Run()
        {
            _runtimeServer.Set("view", "support");
        }
    }
}

