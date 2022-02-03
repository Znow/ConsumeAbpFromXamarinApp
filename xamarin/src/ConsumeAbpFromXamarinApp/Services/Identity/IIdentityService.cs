using System.Threading.Tasks;

namespace ConsumeAbpFromXamarinApp.Services.Identity
{
    public interface IIdentityService
    {
        Task<string> GetAccessTokenAsync();
        Task<bool> LoginAsync(string userName, string password);
        Task<bool> LogoutAsync();
    }
}
