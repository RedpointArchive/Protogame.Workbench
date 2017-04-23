using Horizon.Framework;
using System.Collections.Specialized;
using System.Diagnostics;

namespace Protogame.AppHandlers
{
    public class OpenGitterAppHandler : IAppHandler
    {
        public void Handle(NameValueCollection parameters)
        {
            Process.Start("https://gitter.im/RedpointGames/Protogame");
        }
    }
}
