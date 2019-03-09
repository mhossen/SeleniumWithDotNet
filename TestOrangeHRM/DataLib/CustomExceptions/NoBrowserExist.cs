using System;

namespace DataLib.CustomExceptions
{
    public class NoBrowserExist : Exception
    {
        public NoBrowserExist(string msg) : base(msg)
        {

        }
    }
}
