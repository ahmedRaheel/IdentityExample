using Bookstore.Web.Models;
using System.Threading.Tasks;

namespace Bookstore.Web.Services
{
    public interface IUserService 
    {
        Task<UserInfo> GetUserInfo();
    }
}
