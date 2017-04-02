using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Horizon.Framework
{
    public class AppHandlerManager : IAppHandlerManager
    {
        private Dictionary<string, IAppHandler> _appHandlers;

        private readonly LightweightKernel _kernel;
        private readonly IConfiguration _configuration;

        private bool _appHandlersInit;

        public AppHandlerManager(LightweightKernel kernel, IConfiguration configuration)
        {
            _kernel = kernel;
            _configuration = configuration;
            _appHandlers = new Dictionary<string, IAppHandler>();
            _appHandlersInit = false;
        }

        public void Handle(string absolutePath, NameValueCollection parameters)
        {
            if (!_appHandlersInit)
            {
                _configuration.ConfigureAppHandlers(_kernel, _appHandlers);
                _appHandlersInit = true;
            }

            if (_appHandlers.ContainsKey(absolutePath))
            {
                _appHandlers[absolutePath].Handle(parameters);
            }
        }
    }
}

