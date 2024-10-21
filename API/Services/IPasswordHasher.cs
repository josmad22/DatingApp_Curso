namespace API.Services
{
    public interface IPasswordHasher
    {
        (byte[] passwordHash, byte[] passwordSalt) HashPassword(string password);
        bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt);
    }
}
