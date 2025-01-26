namespace PersonalFinanceApp.Application.Models.Authentication;

public sealed record LoginResponse(string Token, string RefreshToken);
