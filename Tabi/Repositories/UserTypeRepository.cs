using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{
    public interface IUserTypeRepository
    {
        Task<IEnumerable<UserType>> GetUserTypes();
        Task<UserType> GetUserType(int id);
        Task<UserType> PostUserType(UserType userType);
        Task<UserType> PutUserType(int id, UserType userType);
        Task<UserType> DeleteUserType(int id);

    }


    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly TabiContext _context;

        public UserTypeRepository(TabiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserType>> GetUserTypes()
        {
            return await _context.UserTypes.ToListAsync();
        }

        public async Task<UserType> GetUserType(int id)
        {
            return await _context.UserTypes.FindAsync(id);
        }

        public async Task<UserType> PostUserType(UserType userType)
        {
            _context.UserTypes.Add(userType);
            await _context.SaveChangesAsync();
            return userType;
        }

        public async Task<UserType> PutUserType(int id, UserType userType)
        {
            _context.Entry(userType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return userType;
        }

        public async Task<UserType> DeleteUserType(int id)
        {
            var userType = await _context.UserTypes.FindAsync(id);
            if (userType == null)
            {
                return null;
            }

            _context.UserTypes.Remove(userType);
            await _context.SaveChangesAsync();
            return userType;
        }
    }
}
