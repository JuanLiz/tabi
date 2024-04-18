using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User?> GetUser(int id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<User?> DeleteUser(int id);
    }

    public class UserRepository(TabiContext db) : IUserRepository
    {
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await db.Users.ToListAsync();
        }

        public async Task<User?> GetUser(int id)
        {
            return await db.Users.FindAsync(id);
        }

        public async Task<User> CreateUser(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteUser(int id)
        {
            User? user = await db.Users.FindAsync(id);
            if (user == null) return user;
            user.IsActive = false;
            db.Entry(user).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return user;
        }
    }
}
