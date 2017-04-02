using System.Collections.Specialized;

namespace Horizon.Framework
{
	public interface IAppHandlerManager
	{
        void Handle(string absolutePath, NameValueCollection parameters);
	}
}

