using Tabi.Model;
using Tabi.Repositories;

namespace Tabi.Services
{

    public interface IUserService
    {

        Task<AuthResponse?> Authenticate(AuthRequest authRequest);
        Task<IEnumerable<User>> GetUsers();
        Task<User?> GetUser(int id);
        Task<User?> GetUserByUsername(string username, int userTypeID);
        Task<User?> GetUserByEmail(string email, int userTypeID);

        Task<User> CreateUser(
            int UserTypeID,
            string Name,
            string LastName,
            int? DocumentTypeID,
            string? DocumentNumber,
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

        public async Task<AuthResponse?> Authenticate(AuthRequest authRequest)
        {
            return await userRepository.Authenticate(authRequest);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await userRepository.GetUsers();
        }

        public async Task<User?> GetUser(int id)
        {
            return await userRepository.GetUser(id);
        }

        // Get user by username 
        public async Task<User?> GetUserByUsername(string username, int userTypeID)
        {
            return await userRepository.GetUserByUsername(username, userTypeID);
        }

        // Get user by email
        public async Task<User?> GetUserByEmail(string email, int userTypeID)
        {
            return await userRepository.GetUserByEmail(email, userTypeID);
        }

        public async Task<User> CreateUser(
            int UserTypeID,
            string Name,
            string LastName,
            int? DocumentTypeID,
            string? DocumentNumber,
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
