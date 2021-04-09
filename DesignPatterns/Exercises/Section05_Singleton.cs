using System;

namespace DesignPatterns.Exercises.Section05_Singleton
{
    public class SingletonTester
    {
        public static bool IsSingleton(Func<object> func)
        {
            return func() == func();
        }
    }
}
