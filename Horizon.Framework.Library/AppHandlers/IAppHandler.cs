using System;
using System.Collections.Specialized;

namespace Horizon.Framework
{
    public interface IAppHandler
    {
        void Handle(NameValueCollection parameters);
    }
}

