﻿using System;

namespace DataLib.CustomExceptions
{
    public class NoKeyboardKeyExist : Exception
    {
        public NoKeyboardKeyExist(string msg) : base(msg)
        {

        }
    }
}
