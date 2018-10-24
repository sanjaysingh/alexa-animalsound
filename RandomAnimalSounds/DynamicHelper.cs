using System;

namespace RandomAnimalSounds
{
    public static class DynamicHelper
    {
        public static dynamic SafeReadDynamicProperty(dynamic dynamic, string propName)
        {
            var type = (Type)dynamic.GetType();
            var propInfo = type.GetProperty(propName);
            return propInfo != null ? propInfo.GetValue(dynamic) : null;
        }
    }
}
