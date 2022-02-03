using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsumeAbpFromXamarinApp.Services.Http
{
    public interface IHttpClientService<T, C> where T : class where C : class
    {
        Task<T> AuthPostAsync(string uri, string userName, string password);
    }


}
