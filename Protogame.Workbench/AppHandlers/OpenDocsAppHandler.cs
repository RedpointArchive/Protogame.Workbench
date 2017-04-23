using Horizon.Framework;
using System.Collections.Specialized;
using System.Diagnostics;

namespace Protogame.AppHandlers
{
    public class OpenDocsAppHandler : IAppHandler
    {
        public void Handle(NameValueCollection parameters)
        {
            Process.Start("https://protogame.readthedocs.io/");
        }
    }
}
