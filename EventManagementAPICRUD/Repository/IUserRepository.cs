using EventManagementAPICRUD.Models;
using Microsoft.Win32;

namespace EventManagementAPICRUD.Repository
{
    public interface IUserRepository
    {

        Task<User> Register(User user);
        Task<string> Login(string username, string password);
        Task Logout();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
