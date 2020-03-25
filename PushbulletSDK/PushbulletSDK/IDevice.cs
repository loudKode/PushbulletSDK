using PushbulletSDK.JSON;
using System.Threading.Tasks;

namespace PushbulletSDK
{
    public interface IDevice
    {
        Task<bool> Delete(string IDen);
        Task<JSON_DeviceMetadata> Create(string NickName, string Model, string Manufacturer, int? AppVersion, Utilitiez.iconEnum? Icon, bool? HasSMS);
        Task<JSON_DeviceMetadata> Update(string IDen, string NickName, string Model, string Manufacturer, int? AppVersion, Utilitiez.iconEnum? Icon, bool? HasSMS);
        Task<JSON_ListDevices> List();
    }
}
