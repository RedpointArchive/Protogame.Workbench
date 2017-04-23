using System;
using Horizon.Framework;

namespace Protogame.Workflows
{
    public class WelcomeWorkflow : IWorkflow
    {
        private readonly RuntimeServer _runtimeServer;

        public WelcomeWorkflow(RuntimeServer runtimeServer)
        {
            _runtimeServer = runtimeServer;
        }

        public void Run()
        {
            _runtimeServer.Set("view", "welcome");
        }
    }
}

