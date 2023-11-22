using System;

namespace SocialNetworking.Extensions
{
    public static class Extensions
    {
        public static T GetEnvironmentVariable<T>(this string name)
        {
            var value = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Machine);
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static string GetEnvironmentVariable(this string name)
        {
            var value = Environment.GetEnvironmentVariable(name);
            return value;
        }
        public static string ToDbDateTime(this DateTime dateTime)
        {
            var value = dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            return value;
        }
    }
}