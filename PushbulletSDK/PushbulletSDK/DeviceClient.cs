using Newtonsoft.Json;
using PushbulletSDK.JSON;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static PushbulletSDK.Basic;


namespace PushbulletSDK
{
    public class DeviceClient : IDevice
    {
        #region ListDevices
        public async Task<JSON_ListDevices> List()
        {
            using (HtpClient localHttpClient = new HtpClient(new HCHandler()))
            {
                var RequestUri = new pUri("devices");
                using (HttpResponseMessage resPonse = await localHttpClient.GetAsync(RequestUri).ConfigureAwait(false))
                {
                    string result = await resPonse.Content.ReadAsStringAsync();

                    if (resPonse.StatusCode == HttpStatusCode.OK)
                    {
                        return JsonConvert.DeserializeObject<JSON_ListDevices>(result, JSONhandler);
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

        #region UpdateDevice
        public async Task<JSON_DeviceMetadata> Update(string IDen, string NickName, string Model, string Manufacturer, int? AppVersion, Utilitiez.iconEnum? Icon, bool? HasSMS)
        {
            using (HtpClient localHttpClient = new HtpClient(new HCHandler()))
            {
                var HtpReqMessage = new HttpRequestMessage(HttpMethod.Post, new pUri($"devices/{IDen}"));
                var JSONobj = new { nickname = NickName, model = Model, manufacturer = Manufacturer, app_version = AppVersion.Equals(0) | !AppVersion.HasValue ? null : AppVersion, icon = Icon.HasValue ? Icon.ToString() : null, has_sms = HasSMS.HasValue ? HasSMS : null };
                HttpContent streamContent = new StringContent(JsonConvert.SerializeObject(JSONobj, Formatting.None, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }), System.Text.Encoding.UTF8, "application/json");
                HtpReqMessage.Content = streamContent;
                HttpResponseMessage ResPonse = await localHttpClient.SendAsync(HtpReqMessage, HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);
                var result = await ResPonse.Content.ReadAsStringAsync();

                if (ResPonse.StatusCode == HttpStatusCode.OK)
                {
                    var FinRes = JsonConvert.DeserializeObject<JSON_DeviceMetadata>(result, JSONhandler);
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

        #region DeleteDevice
        public async Task<bool> Delete(string IDen)
        {
            using (HtpClient localHttpClient = new HtpClient(new HCHandler()))
            {
                var RequestUri = new pUri($"devices/{IDen}");
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

        #region CreateDevice
        public async Task<JSON_DeviceMetadata> Create(string NickName, string Model, string Manufacturer, int? AppVersion, Utilitiez.iconEnum? Icon, bool? HasSMS)
        {
            using (HtpClient localHttpClient = new HtpClient(new HCHandler()))
            {
                var HtpReqMessage = new HttpRequestMessage(HttpMethod.Post, new pUri("devices"));
                var JSONobj = new { nickname = NickName, model = Model, manufacturer = Manufacturer, app_version = AppVersion.Equals(0) | !AppVersion.HasValue ? null : AppVersion, icon = Icon.HasValue ? Icon.ToString() : null, has_sms = HasSMS.HasValue ? HasSMS : null };
                HttpContent streamContent = new StringContent(JsonConvert.SerializeObject(JSONobj, Formatting.None, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }), System.Text.Encoding.UTF8, "application/json");
                HtpReqMessage.Content = streamContent;
                HttpResponseMessage ResPonse = await localHttpClient.SendAsync(HtpReqMessage, HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);
                var result = await ResPonse.Content.ReadAsStringAsync();

                if (ResPonse.StatusCode == HttpStatusCode.OK)
                {
                    var FinRes = JsonConvert.DeserializeObject<JSON_DeviceMetadata>(result, JSONhandler);
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