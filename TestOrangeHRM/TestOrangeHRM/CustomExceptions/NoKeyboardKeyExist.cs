using System;

namespace TestOrangeHRM.CustomExceptions
{
    public class NoKeyboardKeyExist : Exception
    {
        public NoKeyboardKeyExist(string msg) : base(msg)
        {

        }
    }
}
