using PushbulletSDK.JSON;
using System.Threading.Tasks;

namespace PushbulletSDK
{
    public interface IClient
    {
        // ReadOnly Property Account As IAccount
        IChannel Channel { get; }
        IDevice Device { get; }
        IPush Push { get; }

        Task<JSON_UserInfo> UserInfo();
    }
}

