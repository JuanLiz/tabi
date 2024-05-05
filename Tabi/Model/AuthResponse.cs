namespace Tabi.Model
{
    public class AuthResponse(User user, string Token)
    {

        public int UserID { get; set; } = user.UserID;
        public string Token { get; set; } = Token;
        public string Email { get; set; } = user.Email;
        public string? Username { get; set; } = user.Username;
        public string Name { get; set; } = user.Name;
        public string LastName { get; set; } = user.LastName;
    }
}
