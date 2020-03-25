
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PushbulletSDK.JSON
{

    // // or for all properties in a class
    // <JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)>
    public class Response<TResult>
    {
        public Newtonsoft.Json.Linq.JToken JSON { get; set; }
        public bool Success { get; set; }
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]public string _ErrorMessage { get; set; }
        public int statusCode { get; set; }
        public TResult data { get; set; }
    }

    public class JSON_Error
    {
        public JSON_ErrorError error { get; set; }
    }
    public class JSON_ErrorError
    {
        public int code { get; set; }
        // Public Property type As String
        public string message { get; set; }
    }


    public class JSON_GetToken
    {
        public string sessID { get; set; }
        public string token { get; set; }
    }

    public class JSON_ApiLimits
    {
        public string Limit { get; set; }
        public string Remaining { get; set; }
        public DateTime ResetDate { get; set; }
    }

    public class JSON_UserInfo
    {
        public JSON_ApiLimits ApiLimits { get; set; }
        public bool active { get; set; }
        public string iden { get; set; }
        public float created { get; set; }
        public float modified { get; set; }
        public string email { get; set; }
        public string email_normalized { get; set; }
        public string name { get; set; }
        public string image_url { get; set; }
        public int max_upload_size { get; set; }
    }

    public class JSON_ListDevices
    {
        public JSON_ApiLimits ApiLimits { get; set; }
        public List<JSON_DeviceMetadata> devices { get; set; }
    }
    public class JSON_DeviceMetadata
    {
        public JSON_ApiLimits ApiLimits { get; set; }
        [JsonProperty("active")]
        public bool isExists { get; set; }
        public int app_version { get; set; }
        public string iden { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string nickname { get; set; }
        public string push_token { get; set; }
        [Browsable(false)][Bindable(false)][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][EditorBrowsable(EditorBrowsableState.Never)]public float created { get; set; }
        [Browsable(false)][Bindable(false)][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][EditorBrowsable(EditorBrowsableState.Never)]public float modified { get; set; }

        public DateTime CreatedDate
        {
            get
            {
                return Utilitiez.UnixTimeStampToDateTime(created);
            }
        }

        public DateTime ModifiedDate
        {
            get
            {
                return Utilitiez.UnixTimeStampToDateTime(modified);
            }
        }
    }

    public class JSON_GetUploaadUrl
    {
        public JSON_ApiLimits ApiLimits { get; set; }
        public string file_name { get; set; }
        public string file_type { get; set; }
        public string file_url { get; set; }
        public string upload_url { get; set; }
    }

    public class JSON_ListFollowing
    {
        public JSON_ApiLimits ApiLimits { get; set; }
        public List<JSON_SubscriptionMetadata> subscriptions { get; set; }
    }
    public class JSON_SubscriptionMetadata
    {
        public JSON_ApiLimits ApiLimits { get; set; }
        [JsonProperty("active")]public bool isExists { get; set; }
        public JSON_ChannelMetadata channel { get; set; }
        public string iden { get; set; }
        [Browsable(false)][Bindable(false)][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][EditorBrowsable(EditorBrowsableState.Never)]public float created { get; set; }
        [Browsable(false)][Bindable(false)][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][EditorBrowsable(EditorBrowsableState.Never)]public float modified { get; set; }

        public DateTime CreatedDate
        {
            get
            {
                return Utilitiez.UnixTimeStampToDateTime(created);
            }
        }

        public DateTime ModifiedDate
        {
            get
            {
                return Utilitiez.UnixTimeStampToDateTime(modified);
            }
        }
    }
    public class JSON_ChannelMetadata
    {
        public string description { get; set; }
        public string iden { get; set; }
        public string image_url { get; set; }
        public string name { get; set; }
        public string tag { get; set; }
    }

    public class JSON_MuteChannel
    {
        public JSON_ApiLimits ApiLimits { get; set; }
        public bool muted { get; set; }
    }

    public class JSON_ListPushes
    {
        public JSON_ApiLimits ApiLimits { get; set; }
        public string cursor { get; set; }
        public List<JSON_PushMetadata> pushes { get; set; }
        public bool HasMore
        {
            get
            {
                return string.IsNullOrEmpty(cursor) ? false : true;
            }
        }
    }
    public class JSON_PushMetadata
    {
     public    enum DirectionEnum
        {
            incoming,
            self,
            outgoing
        }
        public JSON_ApiLimits ApiLimits { get; set; }
        [JsonProperty("active")]public bool isExists { get; set; }
        public string body { get; set; }
        [Browsable(false)][Bindable(false)][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][EditorBrowsable(EditorBrowsableState.Never)]public float created { get; set; }
        [Browsable(false)][Bindable(false)][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][EditorBrowsable(EditorBrowsableState.Never)]public float modified { get; set; }
        public DirectionEnum direction { get; set; }
        public bool dismissed { get; set; }
        public string iden { get; set; }
        public string receiver_email { get; set; }
        public string receiver_email_normalized { get; set; }
        public string receiver_iden { get; set; }
        public string sender_email { get; set; }
        public string sender_email_normalized { get; set; }
        public string sender_iden { get; set; }
        public string sender_name { get; set; }
        public string title { get; set; }
        public Utilitiez.PushTypesEnum type { get; set; }
        public string target_device_iden { get; set; }
        public string client_iden { get; set; }
        public string url { get; set; }

        public DateTime CreatedDate
        {
            get
            {
                return Utilitiez.UnixTimeStampToDateTime(created);
            }
        }

        public DateTime ModifiedDate
        {
            get
            {
                return Utilitiez.UnixTimeStampToDateTime(modified);
            }
        }
    }



    public class JSON_AllActivities
    {
        public JSON_ApiLimits ApiLimits { get; set; }
        public string cursor { get; set; }
        public List<JSON_PushMetadata> pushes { get; set; }
        public List<JSON_DeviceMetadata> devices { get; set; }
        public List<JSON_SubscriptionMetadata> subscriptions { get; set; }

        public object accounts { get; set; }
        public object blocks { get; set; }
        public object channels { get; set; }
        public object chats { get; set; }
        public object clients { get; set; }
        public object contacts { get; set; }
        public object grants { get; set; }
        public object profiles { get; set; }
        public object texts { get; set; }
    }
}


