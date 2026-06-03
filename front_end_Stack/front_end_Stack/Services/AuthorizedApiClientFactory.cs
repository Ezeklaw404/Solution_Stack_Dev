using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Authorization;

namespace front_end_Stack.Services;

public class AuthorizedApiClientFactory(
    IHttpClientFactory httpClientFactory,
    AuthenticationStateProvider authenticationStateProvider,
    JwtTokenService jwtTokenService)
{
    public async Task<HttpClient> CreateClientAsync()
    {
        var client = httpClientFactory.CreateClient("Api");
        var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity?.IsAuthenticated == true)
        {
            var token = jwtTokenService.CreateToken(user);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return client;
    }
}
