namespace SFA.DAS.FAA.Legacy.Application.Services
{
    public interface IPasswordHash
    {
        string Generate(string userId, string password, string secretKey);
        bool Validate(string hash, string userId, string password, string secretKey);
    }

    public class PasswordHash : IPasswordHash
    {
        public string Generate(string userId, string password, string secretKey)
        {
            return BCrypt.Net.BCrypt.HashPassword(userId + password + secretKey);
        }

        public bool Validate(string hash, string userId, string password, string secretKey)
        {
            return BCrypt.Net.BCrypt.Verify(userId + password + secretKey, hash);
        }
    }

   
}
