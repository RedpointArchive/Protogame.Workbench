using Horizon.Framework;
using System.Collections.Specialized;
using System.Diagnostics;

namespace Protogame.AppHandlers
{
    public class OpenTwitterAppHandler : IAppHandler
    {
        public void Handle(NameValueCollection parameters)
        {
            Process.Start("https://twitter.com/hachque");
        }
    }
}
