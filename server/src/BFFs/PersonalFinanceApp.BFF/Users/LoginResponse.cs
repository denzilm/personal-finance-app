using System.Text.Json.Serialization;

namespace PersonalFinanceApp.BFF.Users;

public sealed record LoginResponse(
    [property: JsonPropertyName("token")] string Token,
    [property: JsonPropertyName("refreshToken")] string RefreshToken);
