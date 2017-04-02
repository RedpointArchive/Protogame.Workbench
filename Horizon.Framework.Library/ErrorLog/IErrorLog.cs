using System;

namespace Horizon.Framework
{
    public interface IErrorLog
    {
        void Log(Exception ex);

        void Log(string s);
    }
}

