using System;

namespace TestOrangeHRM.Tests
{
    public static class Instantiator
    {
        public static TReturn Create<TParameter, TReturn>(TParameter parameter)
        {
            return (TReturn)Activator.CreateInstance(typeof(TReturn), parameter);
        }
    }
}
