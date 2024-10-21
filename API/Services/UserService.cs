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

        public async Task<bool> AuthenticateUserAsync(string username, string password)
        {
            var user = await _context.User.SingleOrDefaultAsync(u => u.UserName == username);
            if (user == null)
                return false;

            return _passwordHasher.VerifyPassword(password, user.PasswordHash, user.PasswordSalt);
        }

        public async Task<bool> RegisterUserAsync(string username, string email, string password)
        {
            if (await _context.User.AnyAsync(u => u.UserName == username))
                return false;

            var (passwordHash, passwordSalt) = _passwordHasher.HashPassword(password);

            var user = new AppUser
            {
                UserName = username,
                Email = email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
