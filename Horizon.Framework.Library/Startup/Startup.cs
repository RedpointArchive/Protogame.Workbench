using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Horizon.Framework
{
    internal class Startup : IStartup
    {
        private readonly LightweightKernel _kernel;
        private readonly RuntimeServer _runtimeServer;
        private readonly IUIManager _uiManager;
        private readonly IWorkflowManager _workflowManager;
        private readonly IConfiguration _configuration;

        internal Startup(
            LightweightKernel kernel,
            RuntimeServer runtimeServer,
            IWorkflowManager workflowManager,
            IConfiguration configuration,
            IUIManager uiManager)
        {
            _kernel = kernel;
            _runtimeServer = runtimeServer;
            _workflowManager = workflowManager;
            _configuration = configuration;
            _uiManager = uiManager;
        }

        public void Start(string[] args)
        {
            if (args == null)
            {
                args = new string[0];
            }

            if (args.Length == 1)
            {
                if (_configuration.HandleSilentStartup(_kernel, args))
                {
                    return;
                }
            }

            _runtimeServer.Start();

            if (args.Length == 2)
            {
                // The application is being initialised from an external source (like Visual Studio).
                // Set up the runtime server state and jump straight to the specified workflow.
                var workflowType =
                    typeof (Startup).Assembly.GetTypes()
                        .First(x => x.Name == args[0] && typeof (IWorkflow).IsAssignableFrom(x));
                _workflowManager.AppendWorkflow((IWorkflow) _kernel.Get(workflowType));
                var serializer = new JavaScriptSerializer();
                var workflowState = serializer.Deserialize<Dictionary<string, object>>(Encoding.ASCII.GetString(Convert.FromBase64String(args[1])));
                foreach (var kv in workflowState)
                {
                    _runtimeServer.Set(kv.Key, kv.Value);
                }
            }
            else
            {
                _workflowManager.AppendWorkflow(_configuration.GetInitialWorkflow(_kernel));
            }
            
            // Synchronise project templates and IDE add-in in background.
            Task.Run(async () =>
            {
                await _configuration.PerformBackgroundWorkAtStartup(_kernel);
            });

            _workflowManager.Start();
            _uiManager.Run();
        }
    }
}