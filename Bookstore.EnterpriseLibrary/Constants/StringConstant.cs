namespace Bookstore.EnterpriseLibrary.Constants
{
    public class StringConstant
    {
        public const string Authentication_Scheme_Bearer = "Bearer";
        public const string Content_Type_Json = "application/json";
        public const string Identity_Api_Key = "IdentityApiKey";
        public const string Ocelot_Json_File_Name = "ocelot.json";
        public const string Response_Type = "code id_token";
        public const string Client_Id_Policy = "ClientIdPolicy";

      
        public const string Http_Client_Books_Api = "Bookstore Client";
        public const string Http_Client_Idp = "IdpClient";

        public const string Books_Client_Id_Key = "client_id";
        public const string Books_Client_Id_Value = "Bookstore_Web_Client";
        public const string Books_Client_Name = "Bookstore Web App";
        public const string Books_Client_Secret = "secret";

        public const string Role_Admin = "admin";

        public const string Scope_Address = "address";
        public const string Scope_Email = "email";
        public const string Scope_Book_Api_Value = "bookstoreAPI";
        public const string Scope_Book_Api_Text = "BookStore Api";
        public const string Scope_Open_Id = "openid";
        public const string Scope_Profile = "profile";
        public const string Scope_Role_Value = "role";
        public const string Scope_Role_Text = "Role";

        public const string _Api_Route_Name = "api/[controller]";
        public const string Books_Api_Route_Id = "{id}";
        public const string Books_Api_Action_Get_Book = "GetBook";       
    }
}
