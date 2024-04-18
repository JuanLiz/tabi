using Tabi.Model;
using Tabi.Repositories;

namespace Tabi.Services
{

    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User?> GetUser(int id);

        Task<User> CreateUser(
            int UserTypeID,
            string Name,
            string LastName,
            int? DocumentTypeID,
            string DocumentNumber,
            string? Username,
            string Email,
            string Password,
            string? Phone,
            string? Address);
        Task<User> UpdateUser(
            int UserID,
            int? UserTypeID,
            string? Name,
            string? LastName,
            int? DocumentTypeID,
            string? DocumentNumber,
            string? Username,
            string? Email,
            string? Password,
            string? Phone,
            string? Address);
        Task<User?> DeleteUser(int id);

    }

    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await userRepository.GetUsers();
        }

        public async Task<User?> GetUser(int id)
        {
            return await userRepository.GetUser(id);
        }

        public async Task<User> CreateUser(
            int UserTypeID,
            string Name,
            string LastName,
            int? DocumentTypeID,
            string DocumentNumber,
            string? Username,
            string Email,
            string Password,
            string? Phone,
            string? Address)
        {
            User user = new()
            {
                UserTypeID = UserTypeID,
                Name = Name,
                LastName = LastName,
                DocumentTypeID = DocumentTypeID,
                DocumentNumber = DocumentNumber,
                Username = Username,
                Email = Email,
                Password = Password,
                Phone = Phone,
                Address = Address
            };
            return await userRepository.CreateUser(user);
        }

        public async Task<User> UpdateUser(
            int UserID,
            int? UserTypeID,
            string? Name,
            string? LastName,
            int? DocumentTypeID,
            string? DocumentNumber,
            string? Username,
            string? Email,
            string? Password,
            string? Phone,
            string? Address)
        {
            User? user = await userRepository.GetUser(UserID);
            if (user == null) throw new Exception("User not found");
            user.UserTypeID = UserTypeID ?? user.UserTypeID;
            user.Name = Name ?? user.Name;
            user.LastName = LastName ?? user.LastName;
            user.DocumentTypeID = DocumentTypeID ?? user.DocumentTypeID;
            user.DocumentNumber = DocumentNumber ?? user.DocumentNumber;
            user.Username = Username ?? user.Username;
            user.Email = Email ?? user.Email;
            user.Password = Password ?? user.Password;
            user.Phone = Phone ?? user.Phone;
            user.Address = Address ?? user.Address;
            return await userRepository.UpdateUser(user);

        }

        public async Task<User?> DeleteUser(int id)
        {
            return await userRepository.DeleteUser(id);
        }
    }
}
