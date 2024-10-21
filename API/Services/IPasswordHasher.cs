namespace API.Services
{
    public interface IPasswordHasher
    {
        (byte[] PasswordHash, byte[] PasswordSalt) HashPassword(string password);
        bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
