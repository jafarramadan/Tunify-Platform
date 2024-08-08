using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.interfaces
{
    public interface IUsers
    {
        Task<Users> CreateUser(Users user);
        Task<List<Users>> GetAllUsers();
        Task<Users> GetUsersById(int UserId);
        Task<Users> UpdateUser(int UserId, Users user);
        Task<Users> DeleteUser(int UserId);
    }
}