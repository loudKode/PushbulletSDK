using Newtonsoft.Json;
using PushbulletSDK.JSON;
using System;
using System.Collections.Generic;
using System.Text;

namespace PushbulletSDK
{
  public static   class Basic
    {

        public static string APIbase = "https://api.pushbullet.com/v2/";
        public static JsonSerializerSettings JSONhandler = new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Ignore, NullValueHandling = NullValueHandling.Ignore };
        public static string authToken = null;
        public static System.TimeSpan m_TimeOut = System.Threading.Timeout.InfiniteTimeSpan; //' TimeSpan.FromMinutes(60)
        public static bool m_CloseConnection = true;
        public static ConnectionSettings ConnectionSetting = null;


        private static ProxyConfig _proxy;
        public static ProxyConfig m_proxy
        {
            get
            {
                return _proxy ?? new ProxyConfig();
            }
            set
            {
                _proxy = value;
            }
        }


        public class HCHandler : System.Net.Http.HttpClientHandler
        {
            public HCHandler() : base()
            {
                if (m_proxy.SetProxy)
                {
                    base.MaxRequestContentBufferSize = 1 * 1024 * 1024;
                    base.Proxy = new System.Net.WebProxy($"http://{m_proxy.ProxyIP}:{m_proxy.ProxyPort}", true, null, new System.Net.NetworkCredential(m_proxy.ProxyUsername, m_proxy.ProxyPassword));
                    base.UseProxy = m_proxy.SetProxy;
                }
            }
        }

        public class HtpClient : System.Net.Http.HttpClient
        {
            public HtpClient(HCHandler HCHandler) : base(HCHandler)
            {
                base.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                base.DefaultRequestHeaders.UserAgent.ParseAdd("PushbulletSDK");
                base.DefaultRequestHeaders.ConnectionClose = m_CloseConnection;
                base.Timeout = m_TimeOut;
                base.DefaultRequestHeaders.Add("Access-Token", authToken);
            }
            public HtpClient(System.Net.Http.Handlers.ProgressMessageHandler progressHandler) : base(progressHandler)
            {
                base.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                base.DefaultRequestHeaders.UserAgent.ParseAdd("PushbulletSDK");
                base.DefaultRequestHeaders.ConnectionClose = m_CloseConnection;
                base.Timeout = m_TimeOut;
                base.DefaultRequestHeaders.Add("Access-Token", authToken);
            }
        }

        public class pUri : Uri
        {
            public pUri(string ApiAction, Dictionary<string, string> Parameters) : base(APIbase + ApiAction + Utilitiez.AsQueryString(Parameters)) { }
            public pUri(string ApiAction) : base(APIbase + ApiAction) { }
        }

        public static void ShowError(string result)
        {
            JSON_Error errorInfo = JsonConvert.DeserializeObject<JSON_Error>(result, JSONhandler);
            throw new PushbulletException (errorInfo.error.message, errorInfo.error.code);
        }

        public static object  ErrorException(this string result)
        {
            JSON_Error errorInfo = JsonConvert.DeserializeObject<JSON_Error>(result, JSONhandler);
            throw new PushbulletException(errorInfo.error.message, errorInfo.error.code);
            return null;
        }

    }
}
