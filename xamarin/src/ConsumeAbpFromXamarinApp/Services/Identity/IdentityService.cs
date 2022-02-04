using ConsumeAbpFromXamarinApp.Services.Http;
using IdentityModel.OidcClient;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ConsumeAbpFromXamarinApp.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private const string AccessToken = "access_token";
        private const string IdentityToken = "identity_token";
        private const string UserId = "user_id";

        // Get User by email
        public IHttpClientService<IdentityUserDto, IdentityUserDto> HttpClient => DependencyService.Get<IHttpClientService<IdentityUserDto, IdentityUserDto>>();

        public IHttpClientService<IdentityDto, IdentityDto> AuthHttpClient => DependencyService.Get<IHttpClientService<IdentityDto, IdentityDto>>();

        public async Task<bool> LoginAsync(string userName, string password)
        {
            var loginResult = await AuthHttpClient.AuthPostAsync(Global.Settings.Api.TokenUri, userName, password);
            
            if (!string.IsNullOrEmpty(loginResult.error))
            {
                return false;
            }
            
            await SecureStorage.SetAsync(AccessToken, loginResult.access_token);
            
            var customClaims = ExtractCustomClaims(loginResult.access_token);
            
            return true;
        }

        private async Task<bool> WriteTokensAndClaimsToSecureStorageAsync(LoginResult loginResult)
        {
            try
            {
                var customClaims = ExtractCustomClaims(loginResult.AccessToken);

                await SecureStorage.SetAsync(IdentityToken, loginResult.IdentityToken);
                foreach (var claim in loginResult.User.Claims)
                {
                    await SecureStorage.SetAsync(claim.Type, claim.Value);
                }

                await SecureStorage.SetAsync(AccessToken, loginResult.AccessToken);

                var email = await SecureStorage.GetAsync("sub");

                var keyValuePairs = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("email", email)
                };

                var httpContent = new FormUrlEncodedContent(keyValuePairs);

                // Get user by email from HTTP call and save
                await SecureStorage.SetAsync(UserId, email);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                // Possible that device doesn't support secure storage on device.
                //throw new ArgumentException("device doesn't support secure storage on device");
                throw ex;
            }

            return true;
        }

        public JsonDocument ExtractCustomClaims(string accessToken)
        {
            var base64payload = accessToken.Split('.')[1];
            base64payload =
                base64payload.PadRight(base64payload.Length + (base64payload.Length * 3) % 4, '='); // add padding
            var bytes = Convert.FromBase64String(base64payload);
            var jsonPayload = Encoding.UTF8.GetString(bytes);
            var claimsFromAccessToken = JsonDocument.Parse(jsonPayload);
            return claimsFromAccessToken;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            var accessToken = await SecureStorage.GetAsync(AccessToken);
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(accessToken);
                var validTo = jwtToken.ValidTo;
                if (validTo <= DateTime.Now.AddMinutes(5))
                {
                    // await LoginAsync();
                }
                else
                {
                    return accessToken;
                }
            }
            else
            {
                // await LoginAsync();
            }

            return await SecureStorage.GetAsync(AccessToken);
        }

        public async Task<bool> LogoutAsync()
        {
            SecureStorage.Remove(AccessToken);
            var idTokenHint = await SecureStorage.GetAsync(IdentityToken);
            SecureStorage.Remove(IdentityToken);
            SecureStorage.Remove(UserId);
            SecureStorage.Remove("email");
           
            return true;
        }
    }

    public class IdentityDto
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
        public string error { get; set; }
        public string error_description { get; set; }
    }

    public class IdentityUserDto
    {
        //public ExtraProperties extraProperties { get; set; }
        public string id { get; set; }
        public DateTime? creationTime { get; set; }
        public string creatorId { get; set; }
        public DateTime? lastModificationTime { get; set; }
        public string lastModifierId { get; set; }
        public bool isDeleted { get; set; }
        public string deleterId { get; set; }
        public DateTime? deletionTime { get; set; }
        public string tenantId { get; set; }
        public string userName { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public bool emailConfirmed { get; set; }
        public string phoneNumber { get; set; }
        public bool phoneNumberConfirmed { get; set; }
        public bool lockoutEnabled { get; set; }
        public DateTime? lockoutEnd { get; set; }
        public string concurrencyStamp { get; set; }
    }
}