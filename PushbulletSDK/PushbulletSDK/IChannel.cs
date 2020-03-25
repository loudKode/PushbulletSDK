
using PushbulletSDK.JSON;
using System.Threading.Tasks;

namespace PushbulletSDK
{
    public interface IChannel
    {
        Task<JSON_MuteChannel> Mute(string Channel_IDen, bool MuteChannel);
        Task<bool> Leave(string Channel_IDen);
        Task<JSON_SubscriptionMetadata> Join(string ChannelTag);
        Task<JSON_ListFollowing> List();
    }

}