using System.Collections.Generic;

namespace ConsumeAbpFromXamarinApp
{
    public class Global
    {
        public IdentityServer IdentityServer { get; }
        public Api Api { get; }

        public Global(IdentityServer identityServer, Api api)
        {
            IdentityServer = identityServer;
            Api = api;
        }

        public static Global Settings { get; } = new Global(new IdentityServer(), new Api());
    }

    public class IdentityServer
    {
        public readonly string Authority = "https://localhost:44377";

        public readonly string ClientId = "ConsumeAbpFromXamarinApp_Xamarin";
        public readonly string Scope = "email openid profile role phone address ConsumeAbpFromXamarinApp";
        public readonly string ClientSecret = "1q2w3e*";
        public readonly string RedirectUri = "xamarinformsclients://callback";
    }

    public class Api
    {
        private readonly string _apiEndpoint = "https://localhost:44377/api/";
        public readonly string RegularEndpoint = "https://localhost:44377";
        public string TokenUri => RegularEndpoint + "/connect/token";
    }
}
