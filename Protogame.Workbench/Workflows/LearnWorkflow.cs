using System;
using Horizon.Framework;

namespace Protogame.Workflows
{
    public class LearnWorkflow : IWorkflow
    {
        private readonly RuntimeServer _runtimeServer;

        public LearnWorkflow(RuntimeServer runtimeServer)
        {
            _runtimeServer = runtimeServer;
        }

        public void Run()
        {
            _runtimeServer.Set("view", "learn");
        }
    }
}

