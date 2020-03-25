using PushbulletSDK.JSON;
using System;
using System.Threading.Tasks;

namespace PushbulletSDK
{
    public interface IPush
    {
        Task<JSON_ListPushes> List(int Limit);
        Task<JSON_ListPushes> ListContinue(string Cursor, int Limit);
        Task<string> Upload(object FileToUpload, Utilitiez.UploadTypes UploadType, string FileName, IProgress<ReportStatus> ReportCls = null, System.Threading.CancellationToken token = default);
        Task<JSON_PushMetadata> SendToDevice(string DestinationDeviceIDen, Utilitiez.PushTypesEnum PushType, Pushes ThePush);
        Task<JSON_PushMetadata> SendToEmail(string DestinationEmail, Utilitiez.PushTypesEnum PushType, Pushes ThePush);
        Task<JSON_PushMetadata> SendToChannel(string DestinationChannelTag, Utilitiez.PushTypesEnum PushType, Pushes ThePush);
        Task<JSON_PushMetadata> SendToAllAppUsers(string DestinationAppClientIDen, Utilitiez.PushTypesEnum PushType, Pushes ThePush);
        Task<JSON_PushMetadata> Marked(string DestinationPushIDen, bool Seen);
        Task<bool> Delete(string DestinationPushIDen);
        Task<bool> Clear();
    }
}
