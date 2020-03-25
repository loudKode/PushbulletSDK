using Newtonsoft.Json;
using PushbulletSDK.JSON;
using System;
using System.Net;
using System.Threading.Tasks;
using static PushbulletSDK.Basic;

namespace PushbulletSDK
{
    public class PClient : IClient
    {

        public PClient(string AccessToken, ConnectionSettings Settings = null)
        {
            authToken = AccessToken;
            ConnectionSetting = Settings;

            if (Settings == null)
            {
                m_proxy = null;
            }
            else
            {
                m_proxy = Settings.Proxy;
                m_CloseConnection = Settings.CloseConnection ?? true;
                m_TimeOut = Settings.TimeOut ?? TimeSpan.FromMinutes(60);
            }
            ServicePointManager.Expect100Continue = true; ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
        }


        public IChannel Channel { get { return new ChannelClient(); } }
        public IDevice Device { get { return new DeviceClient(); } }
        public IPush Push { get { return new PushClient(); } }



        #region UserInfo
        public async Task<JSON_UserInfo> UserInfo()
        {
            using (HtpClient localHttpClient = new HtpClient(new HCHandler()))
            {
                var RequestUri = new pUri("users/me");
                using (System.Net.Http.HttpResponseMessage resPonse = await localHttpClient.GetAsync(RequestUri).ConfigureAwait(false))
                {
                    string result = await resPonse.Content.ReadAsStringAsync();

                    if (resPonse.StatusCode == HttpStatusCode.OK)
                    {
                        var FinRes = JsonConvert.DeserializeObject<JSON_UserInfo>(result, JSONhandler);
                        // FinRes.ApiLimits = GetApiLimits(resPonse)
                        return FinRes;
                    }
                    else
                    {
                        ShowError(result);
                        return null;
                    }
                }
            }
        }
        #endregion


    }
}

