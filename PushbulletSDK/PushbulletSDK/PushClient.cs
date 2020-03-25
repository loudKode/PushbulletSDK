using Newtonsoft.Json;
using PushbulletSDK.JSON;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static PushbulletSDK.Basic;

namespace PushbulletSDK
{
    public class PushClient : IPush
    {

        #region ListPushes
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Limit">max 500</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public async Task<JSON_ListPushes> List(int Limit)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>() { { "active", "true" }, { "limit", Limit.ToString() } };
            using (HtpClient localHttpClient = new HtpClient(new HCHandler()))
            {
                var RequestUri = new pUri("pushes", parameters);
                using (HttpResponseMessage resPonse = await localHttpClient.GetAsync(RequestUri).ConfigureAwait(false))
                {
                    string result = await resPonse.Content.ReadAsStringAsync();

                    if (resPonse.StatusCode == HttpStatusCode.OK)
                    {
                        var FinRes = JsonConvert.DeserializeObject<JSON_ListPushes>(result, JSONhandler);
                        // FinRes.ApiLimits = GetApiLimits(resPonse)
                        return FinRes;
                    }
                    else
                    {
                        ShowError(result);
                    }

                    return null;
                }
            }
        }
        #endregion

        #region ListPushesContinue
        public async Task<JSON_ListPushes> ListContinue(string Cursor, int Limit)
        {
            var parameters = new Dictionary<string, string>() { { "active", "true" }, { "limit", Limit.ToString() }, { "cursor", Cursor } };
            using (HtpClient localHttpClient = new HtpClient(new HCHandler()))
            {
                var RequestUri = new pUri("pushes", parameters);
                using (HttpResponseMessage resPonse = await localHttpClient.GetAsync(RequestUri).ConfigureAwait(false))
                {
                    string result = await resPonse.Content.ReadAsStringAsync();

                    if (resPonse.StatusCode == HttpStatusCode.OK)
                    {
                        var FinRes = JsonConvert.DeserializeObject<JSON_ListPushes>(result, JSONhandler);
                        // FinRes.ApiLimits = GetApiLimits(resPonse)
                        return FinRes;
                    }
                    else
                    {
                        ShowError(result);
                    }

                    return null;
                }
            }
        }
        #endregion

        #region SendPushToDevice
        public async Task<JSON_PushMetadata> SendToDevice(string DestinationDeviceIDen, Utilitiez.PushTypesEnum PushType, Pushes ThePush)
        {
            object JSONobj = new object();
            switch (PushType)
            {
                case Utilitiez.PushTypesEnum.note:
                    JSONobj = new { device_iden = DestinationDeviceIDen, type = Utilitiez.PushTypesEnum.note.ToString(), title = ThePush.note_push.title, body = ThePush.note_push.body };
                    break;
                case Utilitiez.PushTypesEnum.link:
                    JSONobj = new { device_iden = DestinationDeviceIDen, type = Utilitiez.PushTypesEnum.link.ToString(), title = ThePush.link_push.title, body = ThePush.link_push.body, url = ThePush.link_push.url };
                    break;
                case Utilitiez.PushTypesEnum.file:
                    JSONobj = new { device_iden = DestinationDeviceIDen, type = Utilitiez.PushTypesEnum.file.ToString(), file_name = ThePush.file_push.file_name, body = ThePush.file_push.body, file_type = UptoboxSDK.MimeMapping.GetMimeMapping(ThePush.file_push.file_name), file_url = ThePush.file_push.file_url };
                    break;
            }

            using (HtpClient localHttpClient = new HtpClient(new HCHandler()))
            {
                var HtpReqMessage = new HttpRequestMessage(HttpMethod.Post, new pUri("pushes"));
                HtpReqMessage.Content = new StringContent(JsonConvert.SerializeObject(JSONobj, Formatting.None, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage ResPonse = await localHttpClient.SendAsync(HtpReqMessage, HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);
                var result = await ResPonse.Content.ReadAsStringAsync();

                if (ResPonse.StatusCode == HttpStatusCode.OK)
                {
                    var FinRes = JsonConvert.DeserializeObject<JSON_PushMetadata>(result, JSONhandler);
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

        #region SendPushToEmail
        public async Task<JSON_PushMetadata> SendToEmail(string DestinationEmail, Utilitiez.PushTypesEnum PushType, Pushes ThePush)
        {
            object JSONobj = new object();
            switch (PushType)
            {
                case Utilitiez.PushTypesEnum.note:
                    JSONobj = new { email = DestinationEmail, type = Utilitiez.PushTypesEnum.note.ToString(), title = ThePush.note_push.title, body = ThePush.note_push.body };
                    break;
                case Utilitiez.PushTypesEnum.link:
                    JSONobj = new { email = DestinationEmail, type = Utilitiez.PushTypesEnum.link.ToString(), title = ThePush.link_push.title, body = ThePush.link_push.body, url = ThePush.link_push.url };
                    break;
                case Utilitiez.PushTypesEnum.file:
                    JSONobj = new { email = DestinationEmail, type = Utilitiez.PushTypesEnum.file.ToString(), file_name = ThePush.file_push.file_name, body = ThePush.file_push.body, file_type = UptoboxSDK.MimeMapping.GetMimeMapping(ThePush.file_push.file_name), file_url = ThePush.file_push.file_url };
                    break;
            }

            using (HtpClient localHttpClient = new HtpClient(new HCHandler()))
            {
                var HtpReqMessage = new HttpRequestMessage(HttpMethod.Post, new pUri("pushes"));
                HtpReqMessage.Content = new StringContent(JsonConvert.SerializeObject(JSONobj, Formatting.None, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage ResPonse = await localHttpClient.SendAsync(HtpReqMessage, HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);
                var result = await ResPonse.Content.ReadAsStringAsync();

                if (ResPonse.StatusCode == HttpStatusCode.OK)
                {
                    var FinRes = JsonConvert.DeserializeObject<JSON_PushMetadata>(result, JSONhandler);
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

        #region SendPushToChannel
        public async Task<JSON_PushMetadata> SendToChannel(string DestinationChannelTag, Utilitiez.PushTypesEnum PushType, Pushes ThePush)
        {
            object JSONobj = new object();
            switch (PushType)
            {
                case Utilitiez.PushTypesEnum.note:
                    JSONobj = new { channel_tag = DestinationChannelTag, type = Utilitiez.PushTypesEnum.note.ToString(), title = ThePush.note_push.title, body = ThePush.note_push.body };
                    break;
                case Utilitiez.PushTypesEnum.link:
                    JSONobj = new { channel_tag = DestinationChannelTag, type = Utilitiez.PushTypesEnum.link.ToString(), title = ThePush.link_push.title, body = ThePush.link_push.body, url = ThePush.link_push.url };
                    break;
                case Utilitiez.PushTypesEnum.file:
                    JSONobj = new { channel_tag = DestinationChannelTag, type = Utilitiez.PushTypesEnum.file.ToString(), file_name = ThePush.file_push.file_name, body = ThePush.file_push.body, file_type = UptoboxSDK.MimeMapping.GetMimeMapping(ThePush.file_push.file_name), file_url = ThePush.file_push.file_url };
                    break;
            }

            using (HtpClient localHttpClient = new HtpClient(new HCHandler()))
            {
                var HtpReqMessage = new HttpRequestMessage(HttpMethod.Post, new pUri("pushes"));
                HtpReqMessage.Content = new StringContent(JsonConvert.SerializeObject(JSONobj, Formatting.None, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage ResPonse = await localHttpClient.SendAsync(HtpReqMessage, HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);
                var result = await ResPonse.Content.ReadAsStringAsync();

                if (ResPonse.StatusCode == HttpStatusCode.OK)
                {
                    var FinRes = JsonConvert.DeserializeObject<JSON_PushMetadata>(result, JSONhandler);
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

        #region SendPushToAllAppUsers
        public async Task<JSON_PushMetadata> SendToAllAppUsers(string DestinationAppClientIDen, Utilitiez.PushTypesEnum PushType, Pushes ThePush)
        {
            object JSONobj = new object();
            switch (PushType)
            {
                case Utilitiez.PushTypesEnum.note:
                    JSONobj = new { client_iden = DestinationAppClientIDen, type = Utilitiez.PushTypesEnum.note.ToString(), title = ThePush.note_push.title, body = ThePush.note_push.body };
                    break;
                case Utilitiez.PushTypesEnum.link:
                    JSONobj = new { client_iden = DestinationAppClientIDen, type = Utilitiez.PushTypesEnum.link.ToString(), title = ThePush.link_push.title, body = ThePush.link_push.body, url = ThePush.link_push.url };
                    break;
                case Utilitiez.PushTypesEnum.file:
                    JSONobj = new { client_iden = DestinationAppClientIDen, type = Utilitiez.PushTypesEnum.file.ToString(), file_name = ThePush.file_push.file_name, body = ThePush.file_push.body, file_type = UptoboxSDK.MimeMapping.GetMimeMapping(ThePush.file_push.file_name), file_url = ThePush.file_push.file_url };
                    break;
            }

            using (HtpClient localHttpClient = new HtpClient(new HCHandler()))
            {
                var HtpReqMessage = new HttpRequestMessage(HttpMethod.Post, new pUri("pushes"));
                HtpReqMessage.Content = new StringContent(JsonConvert.SerializeObject(JSONobj, Formatting.None, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage ResPonse = await localHttpClient.SendAsync(HtpReqMessage, HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);
                var result = await ResPonse.Content.ReadAsStringAsync();

                if (ResPonse.StatusCode == HttpStatusCode.OK)
                {
                    var FinRes = JsonConvert.DeserializeObject<JSON_PushMetadata>(result, JSONhandler);
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

        #region PushMarked
        public async Task<JSON_PushMetadata> Marked(string DestinationPushIDen, bool Seen)
        {
            using (HtpClient localHttpClient = new HtpClient(new HCHandler()))
            {
                var HtpReqMessage = new HttpRequestMessage(HttpMethod.Post, new pUri($"pushes/{DestinationPushIDen}"));
                HtpReqMessage.Content = new StringContent(JsonConvert.SerializeObject(new { dismissed = Seen }), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage ResPonse = await localHttpClient.SendAsync(HtpReqMessage, HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);
                var result = await ResPonse.Content.ReadAsStringAsync();

                if (ResPonse.StatusCode == HttpStatusCode.OK)
                {
                    var FinRes = JsonConvert.DeserializeObject<JSON_PushMetadata>(result, JSONhandler);
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

        #region DeletePush
        public async Task<bool> Delete(string DestinationPushIDen)
        {
            using (HtpClient localHttpClient = new HtpClient(new HCHandler()))
            {
                var RequestUri = new pUri(string.Format("pushes/{0}", DestinationPushIDen));
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

        #region DeleteAllPushes
        public async Task<bool> Clear()
        {
            using (HtpClient localHttpClient = new HtpClient(new HCHandler()))
            {
                var RequestUri = new pUri("pushes");
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

        #region Upload
        private async Task<JSON_GetUploaadUrl> GetUploaadUrl(string FileName, string FileType)
        {
            using (HtpClient localHttpClient = new HtpClient(new HCHandler()))
            {
                var HtpReqMessage = new HttpRequestMessage(HttpMethod.Post, new pUri("upload-request"));
                var JSONobj = new { file_name = FileName, file_type = FileType };
                HtpReqMessage.Content = new StringContent(JsonConvert.SerializeObject(JSONobj), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage ResPonse = await localHttpClient.SendAsync(HtpReqMessage, HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);
                var result = await ResPonse.Content.ReadAsStringAsync();

                if (ResPonse.StatusCode == HttpStatusCode.OK)
                {
                    var FinRes = JsonConvert.DeserializeObject<JSON_GetUploaadUrl>(result, JSONhandler);
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


        public async Task<string> Upload(object FileToUpload, Utilitiez.UploadTypes UploadType, string FileName, IProgress<ReportStatus> ReportCls = null, CancellationToken token = default)
        {
            var uploadUrl = await GetUploaadUrl(FileName, UptoboxSDK.MimeMapping.GetMimeMapping(FileName));

            ReportCls = ReportCls ?? new Progress<ReportStatus>();
            ReportCls.Report(new ReportStatus() { Finished = false, TextStatus = "Initializing..." });
            try
            {
                var progressHandler = new System.Net.Http.Handlers.ProgressMessageHandler(new HCHandler());
                progressHandler.HttpSendProgress += (sender, e) => { ReportCls.Report(new ReportStatus() { ProgressPercentage = e.ProgressPercentage, BytesTransferred = e.BytesTransferred, TotalBytes = e.TotalBytes ?? 0, TextStatus = "Uploading..." }); };
                // '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                using (HtpClient localHttpClient = new HtpClient(progressHandler))
                {
                    HttpRequestMessage HtpReqMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(uploadUrl.upload_url));
                    var MultipartsformData = new MultipartFormDataContent();
                    StreamContent streamContent = null;
                    // streamContent.Headers.ContentType = New Net.Http.Headers.MediaTypeHeaderValue(Web.MimeMapping.GetMimeMapping(FileName))
                    switch (UploadType)
                    {
                        case Utilitiez.UploadTypes.FilePath:
                            streamContent = new StreamContent(new System.IO.FileStream(FileToUpload.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read));
                            break;
                        case Utilitiez.UploadTypes.Stream:
                            streamContent = new StreamContent((System.IO.Stream)FileToUpload);
                            break;
                        case Utilitiez.UploadTypes.BytesArry:
                            streamContent = new StreamContent(new System.IO.MemoryStream((byte[])FileToUpload));
                            break;
                    }

                    // streamContent.Headers.ContentDisposition = New System.Net.Http.Headers.ContentDispositionHeaderValue("form-data") With {.Name = """files[]""", .FileName = """" + FileName + """"}
                    // streamContent.Headers.ContentType = New Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream")
                    MultipartsformData.Add(streamContent, "file", FileName);
                    HtpReqMessage.Content = MultipartsformData;
                    // ''''''''''''''''will write the whole content to H.D WHEN download completed'''''''''''''''''''''''''''''
                    using (HttpResponseMessage ResPonse = await localHttpClient.SendAsync(HtpReqMessage, HttpCompletionOption.ResponseContentRead, token).ConfigureAwait(false))
                    {
                        token.ThrowIfCancellationRequested();
                        if (ResPonse.StatusCode == HttpStatusCode.NoContent)
                        {
                            ReportCls.Report(new ReportStatus() { Finished = true, TextStatus = $"[{FileName}] Uploaded successfully" });
                            return uploadUrl.file_url;
                        }
                        else
                        {
                            string result = await ResPonse.Content.ReadAsStringAsync();
                            ReportCls.Report(new ReportStatus() { Finished = true, TextStatus = $"The request returned with HTTP status code {ResPonse.ReasonPhrase}" });
                            ShowError(result);
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ReportCls.Report(new ReportStatus() { Finished = true });
                if (ex.Message.ToString().ToLower().Contains("a task was canceled"))
                {
                    ReportCls.Report(new ReportStatus() { TextStatus = ex.Message });
                }
                else
                {
                    throw new PushbulletException(ex.Message, 1001);
                }
                return null;
            }
        }
        #endregion


    }
}


