using System;

namespace PushbulletSDK
{
    public class PushbulletException : Exception
    {
        public PushbulletException(string errorMesage, int errorCode) : base(errorMesage) { }
    }
}
