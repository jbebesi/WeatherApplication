// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using IdentityModel.Client;
using System.Text.Json;

// discover endpoints from metadata
var client = new HttpClient();
//string baseUrl = "https://wettadev.azurewebsites.net";
string baseUrl = "https://localhost:5001";
var disco = await client.GetDiscoveryDocumentAsync(baseUrl);
if (disco.IsError)
{
    Console.WriteLine(disco.Error);
    return;
}

// request token
var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
{
    Address = disco.TokenEndpoint,
    ClientId = "TestClient",
    ClientSecret = "secret",
    Scope = "Weather"
});

if (tokenResponse.IsError)
{
    Console.WriteLine($"Error: {tokenResponse.Error} Description: {tokenResponse.ErrorDescription}");
    return;
}

Console.WriteLine(tokenResponse.Json);
Console.WriteLine("\n\n");

// call api
var apiClient = new HttpClient();
apiClient.SetBearerToken(tokenResponse.AccessToken);

try
{
    var cityUrl = $"{baseUrl}/api/citylist";
    Console.WriteLine($"open Citylist: {cityUrl}");
    var response = await apiClient.GetAsync(cityUrl);
    if (!response.IsSuccessStatusCode)
    {
        Console.WriteLine($"{response.StatusCode} content: {await response.Content.ReadAsStringAsync()}");
    }
    else
    {
        Console.WriteLine("Error:");
        var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
        Console.WriteLine(JsonSerializer.Serialize(doc, new JsonSerializerOptions { WriteIndented = true }));
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}