using System.Collections.Generic;

namespace Bookstore.Web.Models
{
    public class UserInfo
    {
        public Dictionary<string, string> UserInfoDictionary { get; private set; } = null;

        public UserInfo(Dictionary<string, string> userInfoDictionary)
        {
            UserInfoDictionary = userInfoDictionary;
        }
    }
}
