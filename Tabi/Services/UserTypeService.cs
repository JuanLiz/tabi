using Tabi.Model;
using Tabi.Repositories;

namespace Tabi.Services
{

    public interface IUserTypeService
    {
        Task<IEnumerable<UserType>> GetUserTypes();
        Task<UserType?> GetUserType(int id);
        Task<UserType> CreateUserType(string Name);
        Task<UserType> UpdateUserType(int UserTypeID, string? Name);
        Task<UserType?> DeleteUserType(int id);

    }

    public class UserTypeService(IUserTypeRepository userTypeRepository) : IUserTypeService
    {
        public async Task<IEnumerable<UserType>> GetUserTypes()
        {
            return await userTypeRepository.GetUserTypes();
        }

        public async Task<UserType?> GetUserType(int id)
        {
            return await userTypeRepository.GetUserType(id);
        }

        public async Task<UserType> CreateUserType(string Name)
        {
            UserType userType = new() { Name = Name };
            return await userTypeRepository.CreateUserType(userType);
        }

        public async Task<UserType> UpdateUserType(int UserTypeID, string? Name)
        {
            UserType? userType = await userTypeRepository.GetUserType(UserTypeID);
            if (userType == null) throw new Exception("UserType not found");
            userType.Name = Name ?? userType.Name;
            return await userTypeRepository.UpdateUserType(userType);
        }

        public async Task<UserType?> DeleteUserType(int id)
        {
            return await userTypeRepository.DeleteUserType(id);
        }
    }
}
