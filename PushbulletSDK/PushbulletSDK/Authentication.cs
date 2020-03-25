using System;
using System.Collections.Generic;
using System.Text;

namespace PushbulletSDK
{
  public   class Authentication
    {

        enum ResponseType
        {
            token,
            code,
            authorization_code,
            password,
            refresh_token
        }
        public static string GetToken(string ClientID, string RedirectUrl)
        {
            string URL = "https://www.pushbullet.com/authorize";
            var parameters = new Dictionary<string, string>();
            parameters.Add("response_type", ResponseType.token.ToString());
            parameters.Add("client_id", ClientID);
            parameters.Add("redirect_uri", RedirectUrl ?? "https://loudkode.github.io/Apps/app.html");
            parameters.Add("scope", "everything");
            return  URL + Utilitiez.AsQueryString(parameters);
        }



    }
}
