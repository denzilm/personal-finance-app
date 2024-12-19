namespace PersonalFinanceApp.BFF.Users;

public sealed class IdentityClient : IIdentityClient
{
    private readonly HttpClient _httpClient;

    public IdentityClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> RegisterUserAsync(RegisterRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("api/v1/users/register", request);
        return response.IsSuccessStatusCode;
    }
}
