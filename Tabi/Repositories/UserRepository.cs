using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface IUserRepository
    {
        Task<AuthResponse?> Authenticate(AuthRequest authRequest);
        Task<IEnumerable<User>> GetUsers();
        Task<User?> GetUser(int id);
        Task<User?> GetUserByUsername(string username, int userTypeID);
        Task<User?> GetUserByEmail(string email, int userTypeID);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<User?> DeleteUser(int id);
    }

    public class UserRepository(IOptions<AuthSettings> authSettings, TabiContext db, IUserTypeRepository userTypeRepository) : IUserRepository
    {

        private readonly AuthSettings authSettings = authSettings.Value;


        public async Task<AuthResponse?> Authenticate(AuthRequest authRequest)
        {
            User? user;

            // Check for username or email
            if (authRequest.Username == null)
            {
                user = await db.Users.FirstOrDefaultAsync(u =>
                    u.Email.Equals(authRequest.Email)
                    && u.Password.Equals(authRequest.Password));
            }
            else
            {
                user = await db.Users.FirstOrDefaultAsync(u =>
                    u.Username != null
                    && u.Username.Equals(authRequest.Username)
                    && u.Password.Equals(authRequest.Password));
            }


            if (user == null) return null;

            // Generate JWT
            string token = await GenerateJwtToken(user);

            return new AuthResponse(user, token);
        }

        // helper methods
        private async Task<string> GenerateJwtToken(User user)
        {
            UserType? userType = await userTypeRepository.GetUserType(user.UserTypeID);

            //Generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() =>
            {
                byte[] key = Encoding.ASCII.GetBytes(authSettings.Secret);
                SecurityTokenDescriptor tokenDescriptor = new()
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserID.ToString()) }),
                    Expires = DateTime.UtcNow.AddDays(userType?.Name == "Jugador" ? 28 : 7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.CreateToken(tokenDescriptor);
            });

            return tokenHandler.WriteToken(token);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await db.Users.ToListAsync();
        }

        public async Task<User?> GetUser(int id)
        {
            return await db.Users.FindAsync(id);
        }

        public async Task<User?> GetUserByUsername(string username, int userTypeID)
        {
            return await db.Users.FirstOrDefaultAsync(u => u.Username == username && u.UserTypeID == userTypeID);
        }

        public async Task<User?> GetUserByEmail(string email, int userTypeID)
        {
            return await db.Users.FirstOrDefaultAsync(u => u.Email == email && u.UserTypeID == userTypeID);
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
