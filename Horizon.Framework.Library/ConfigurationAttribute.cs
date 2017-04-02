using System;

namespace Horizon.Framework
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class ConfigurationAttribute : Attribute
    {
        public Type Type { get; private set; }

        public ConfigurationAttribute(Type type)
        {
            Type = type;
        }
    }
}
