using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PushbulletSDK
{
    public class Utilitiez
    {

        public static string AsQueryString(Dictionary<string, string> parameters)
        {
            if (!parameters.Any()) { return string.Empty; }

            var builder = new StringBuilder("?");
            var separator = string.Empty;
            foreach (var kvp in parameters.Where(P => !string.IsNullOrEmpty(P.Value)))
            {
                builder.AppendFormat("{0}{1}={2}", separator, System.Net.WebUtility.UrlEncode(kvp.Key), System.Net.WebUtility.UrlEncode(kvp.Value.ToString()));
                separator = "&";
            }
            return builder.ToString();
        }

        public static string Between(string source, string leftString, string rightString)
        {
            return System.Text.RegularExpressions.Regex.Match(source, string.Format("{0}(.*){1}", leftString, rightString)).Groups[1].Value;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public enum UploadTypes
        {
            FilePath,
            Stream,
            BytesArry
        }
        public enum iconEnum
        {
            ios,
            desktop,
            browser,
            website,
            laptop,
            tablet,
            phone,
            watch,
            system
        }
        public enum PushTypesEnum
        {
            file,
            link,
            note
        }
        public enum SortEnum
        {
            asc,
            desc
        }



    }
}
