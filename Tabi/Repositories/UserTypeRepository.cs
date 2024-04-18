using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{
    public interface IUserTypeRepository
    {
        Task<IEnumerable<UserType>> GetUserTypes();
        Task<UserType?> GetUserType(int id);
        Task<UserType> CreateUserType(UserType userType);
        Task<UserType> UpdateUserType(UserType userType);
        Task<UserType?> DeleteUserType(int id);
    }


    public class UserTypeRepository(TabiContext db) : IUserTypeRepository
    {
        public async Task<IEnumerable<UserType>> GetUserTypes()
        {
            return await db.UserTypes.ToListAsync();
        }

        public async Task<UserType?> GetUserType(int id)
        {
            return await db.UserTypes.FindAsync(id);
        }

        public async Task<UserType> CreateUserType(UserType userType)
        {
            db.UserTypes.Add(userType);
            await db.SaveChangesAsync();
            return userType;
        }

        public async Task<UserType> UpdateUserType(UserType userType)
        {
            db.Entry(userType).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return userType;
        }

        public async Task<UserType?> DeleteUserType(int id)
        {
            UserType? userType = await db.UserTypes.FindAsync(id);
            if (userType == null) return userType;
            userType.IsActive = false;
            db.Entry(userType).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return userType;
        }
    }
}
