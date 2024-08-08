using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class UsersServices : IUsers
    {
        private readonly TunifyAppDbContext _context;

        public UsersServices(TunifyAppDbContext context)
        {
            _context = context;
        }
        public async Task<Users> CreateUser(Users user)
        {
           _context.Users.Add(user);    
          await  _context.SaveChangesAsync();

            return user;
        }

        public async Task<Users> DeleteUser(int UserId)
        {
           // var exUser = await _context.Users.FindAsync(UserId);
            var exUser = await GetUsersById(UserId);
            _context.Users.Remove(exUser);
            await _context.SaveChangesAsync();
            return exUser;
        }

        public async Task<List<Users>> GetAllUsers()
        {
         var allUsers=  await _context.Users.ToListAsync();
            return allUsers;
        }

        public async Task<Users> GetUsersById(int UserId)
        {
            var user = await _context.Users.FindAsync(UserId);
            return user;
        }

        public async Task<Users> UpdateUser(int UserId, Users user)
        {
            var exUser = await _context.Users.FindAsync(UserId);
            exUser=user;
            _context.SaveChanges();
            return exUser;
        }
    }
}
