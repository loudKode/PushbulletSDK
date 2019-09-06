using System;
using System.Threading;
using System.Threading.Tasks;
using PushbulletSDK.JSON;

namespace PushbulletSDK
{
	public interface IClient
	{
		Task<JSON_UserInfo> UserInfo();

		Task<JSON_ListPushes> ListPushes(int Limit);

		Task<JSON_ListPushes> ListPushesContinue(string Cursor, int Limit);

		Task<JSON_MuteChannel> MuteChannel(string Channel_IDen, bool Mute);

		Task<bool> UnSubscribeChannel(string Channel_IDen);

		Task<JSON_SubscriptionMetadata> SubscribeToChannel(string ChannelTag);

		Task<JSON_ListFollowing> ListChannels();

		Task<string> Upload(object FileToUpload, PClient.UploadTypes UploadType, string FileName, IProgress<ReportStatus> ReportCls = null, ProxyConfig _proxi = null, CancellationToken token = default(CancellationToken));

		Task<bool> DeleteDevice(string IDen);

		Task<JSON_DeviceMetadata> CreateDevice(string nickname, string model, string manufacturer, int app_version, Putilities.iconEnum? icon, bool? has_sms);

		Task<JSON_DeviceMetadata> UpdateDevice(string IDen, string nickname, string model, string manufacturer, int app_version, Putilities.iconEnum? icon, bool? has_sms);

		Task<JSON_ListDevices> ListDevices();

		Task<JSON_PushMetadata> SendPushToDevice(string DestinationDeviceIDen, Putilities.PushTypesEnum PushType, Pushes ThePush);

		Task<JSON_PushMetadata> SendPushToEmail(string DestinationEmail, Putilities.PushTypesEnum PushType, Pushes ThePush);

		Task<JSON_PushMetadata> SendPushToChannel(string DestinationChannelTag, Putilities.PushTypesEnum PushType, Pushes ThePush);

		Task<JSON_PushMetadata> SendPushToAllAppUsers(string DestinationAppClientIDen, Putilities.PushTypesEnum PushType, Pushes ThePush);

		Task<JSON_PushMetadata> PushMarked(string DestinationPushIDen, bool Seen);

		Task<bool> DeletePush(string DestinationPushIDen);

		Task<bool> DeleteAllPushes();
	}
}
