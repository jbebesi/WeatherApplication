using Duende.IdentityServer.Models;
using System.Collections.Generic;

namespace WeatherApplication.Server.Identity
{
    using Client = Duende.IdentityServer.Models.Client;
    public static class IdentityConfig
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("Weather", "WettaApi")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
            new Client
            {
                ClientId = "BrowserClient",
                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                // secret for authentication
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                // scopes that client has access to
                AllowedScopes = { "Weather" }
            }
            };
    }
}
