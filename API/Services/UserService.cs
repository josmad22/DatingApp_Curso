using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(DataContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> AuthenticateUser(string email, string password)
        {
            var user = await _context.User.SingleOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return false;

            return _passwordHasher.VerifyPassword(password, user.PasswordHash, user.PasswordSalt);
        }

        public async Task<bool> RegisterUser(string email, string password, string userName)
        {
            if (await _context.User.AnyAsync(u => u.Email == email))
                return false;

            var (passwordHash, passwordSalt) = _passwordHasher.HashPassword(password);

            var user = new AppUser
            {
                Email = email,
                UserName = userName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
