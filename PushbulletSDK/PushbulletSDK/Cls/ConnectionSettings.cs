using System;
using System.Collections.Generic;
using System.Text;
using PushbulletSDK;

namespace PushbulletSDK
{
    public class ConnectionSettings
    {
        public TimeSpan? TimeOut = null;
        public bool? CloseConnection = true;
        public ProxyConfig Proxy = null;
    }
}
