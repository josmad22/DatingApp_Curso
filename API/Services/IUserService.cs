namespace API.Services
{
    public interface IUserService
    {
        Task<bool> AuthenticateUserAsync(string username, string password);
        Task<bool> RegisterUserAsync(string username, string email, string password);
    }
}
