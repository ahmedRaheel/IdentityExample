namespace Bookstore.EnterpriseLibrary.Constants
{
    public class Url
    {
        public const string Api_Gateway = "https://localhost:5003";
        public const string Identity_Server = "https://localhost:5005";
        public const string Books_Api = "https://localhost:5001";
        public const string Books_Client = "https://localhost:5002";

        public const string Sign_In = Books_Client + "/signin-oidc";
        public const string Sign_Out = Books_Client + "/signout-callback-oidc";

        public const string Books = "/books";
        public const string Books_Id = "/books/{0}";
    }
}
