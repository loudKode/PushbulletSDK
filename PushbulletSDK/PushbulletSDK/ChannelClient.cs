using Newtonsoft.Json;
using PushbulletSDK.JSON;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static PushbulletSDK.Basic;

namespace PushbulletSDK
{
    public class ChannelClient : IChannel
    {

        #region ListChannels
        public async Task<JSON_ListFollowing> List()
        {
            using (HtpClient localHttpClient = new HtpClient(new HCHandler()))
            {
                var RequestUri = new pUri("subscriptions");
                using (HttpResponseMessage resPonse = await localHttpClient.GetAsync(RequestUri).ConfigureAwait(false))
                {
                    string result = await resPonse.Content.ReadAsStringAsync();

                    if (resPonse.StatusCode == HttpStatusCode.OK)
                    {
                        var FinRes = JsonConvert.DeserializeObject<JSON_ListFollowing>(result, JSONhandler);
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

        #region SubscribeToChannel
        public async Task<JSON_SubscriptionMetadata> Join(string ChannelTag)
        {
            using (HtpClient localHttpClient = new HtpClient(new HCHandler()))
            {
                var HtpReqMessage = new HttpRequestMessage(HttpMethod.Post, new pUri("subscriptions"));
                HtpReqMessage.Content = new StringContent(JsonConvert.SerializeObject(new { channel_tag = ChannelTag }), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage ResPonse = await localHttpClient.SendAsync(HtpReqMessage, HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);
                var result = await ResPonse.Content.ReadAsStringAsync();

                if (ResPonse.StatusCode == HttpStatusCode.OK)
                {
                    var FinRes = JsonConvert.DeserializeObject<JSON_SubscriptionMetadata>(result, JSONhandler);
                    // FinRes.ApiLimits = GetApiLimits(ResPonse)
                    return FinRes;
                }
                else
                {
                    ShowError(result);
                    return null;
                }
            }
        }
        #endregion

        #region UnSubscribeChannel
        public async Task<bool> Leave(string Channel_IDen)
        {
            using (HtpClient localHttpClient = new HtpClient(new HCHandler ()))
            {
                var RequestUri = new pUri($"subscriptions/{Channel_IDen}");
                HttpResponseMessage ResPonse = await localHttpClient.DeleteAsync(RequestUri).ConfigureAwait(false);
                var result = await ResPonse.Content.ReadAsStringAsync();

                if (ResPonse.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    ShowError(result);
                    return false;
                }
            }
        }
        #endregion

        #region MuteChannel
        public async Task<JSON_MuteChannel> Mute(string Channel_IDen, bool Mute)
        {
            using (HtpClient localHttpClient = new HtpClient(new HCHandler ()))
            {
                var HtpReqMessage = new HttpRequestMessage(HttpMethod.Post, new pUri($"subscriptions/{Channel_IDen}"));
                HtpReqMessage.Content = new StringContent(JsonConvert.SerializeObject(new { muted = Mute }), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage ResPonse = await localHttpClient.SendAsync(HtpReqMessage, HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);
                var result = await ResPonse.Content.ReadAsStringAsync();

                if (ResPonse.StatusCode == HttpStatusCode.OK)
                {
                    var FinRes = JsonConvert.DeserializeObject<JSON_MuteChannel>(result, JSONhandler);
                    // FinRes.ApiLimits = GetApiLimits(ResPonse)
                    return FinRes;
                }
                else
                {
                    ShowError(result);
                    return null;
                }
            }
        }
        #endregion

       
    }
}
