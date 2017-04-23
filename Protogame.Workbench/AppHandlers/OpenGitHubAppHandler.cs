using Horizon.Framework;
using System.Collections.Specialized;
using System.Diagnostics;

namespace Protogame.AppHandlers
{
    public class OpenGitHubAppHandler : IAppHandler
    {
        public void Handle(NameValueCollection parameters)
        {
            Process.Start("https://github.com/RedpointGames/Protogame/issues");
        }
    }
}
