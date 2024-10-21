namespace API.Services
{
    public interface IUserService
    {
        Task<bool> AuthenticateUser(string email, string password);
        Task<bool> RegisterUser(string email, string password, string userName);
    }
}
