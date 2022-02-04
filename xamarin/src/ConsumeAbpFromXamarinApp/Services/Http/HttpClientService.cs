using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ConsumeAbpFromXamarinApp.Services.Identity;
using System.Text.Json;

namespace ConsumeAbpFromXamarinApp.Services.Http
{
    public class HttpClientService<T, C> : IHttpClientService<T, C> where T : class where C : class
    {
        public IIdentityService IdentityService => DependencyService.Get<IIdentityService>();
        Lazy<HttpClient> _httpClient;
        private async Task<string> GetAccessTokenAsync() => await IdentityService.GetAccessTokenAsync();

        private JsonSerializerOptions Options => new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true // this is the point
        };

        public async Task<T> AuthPostAsync(string uri, string userName, string password)
        {
            _httpClient = await GetHttpClientAsync();

            var data = $"grant_type=password";
            data += $"&username={userName}";
            data += $"&password={password}";
            data += $"&client_id={Global.Settings.IdentityServer.ClientId}";
            data += $"&client_secret={Global.Settings.IdentityServer.ClientSecret}";
            data += $"&scope={Global.Settings.IdentityServer.Scope}";
            
            var content = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await _httpClient.Value.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();

            var stringResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<T>(stringResult, Options);
            return result;
        }

        private HttpClientHandler GetHttpClientHandler()
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // EXCEPTION : Javax.Net.Ssl.SSLHandshakeException: 'java.security.cert.CertPathValidatorException: Trust anchor for certification path not found.'
            // SOLUTION :

            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
            };

            return httpClientHandler;
        }

        private async Task<Lazy<HttpClient>> GetHttpClientAsync()
        {
            var accessToken = await GetAccessTokenAsync();
            var httpClient = new Lazy<HttpClient>(() => new HttpClient(GetHttpClientHandler()));
            httpClient.Value.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken ?? "");
            return httpClient;
        }
    }
}
