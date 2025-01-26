namespace PersonalFinanceApp.BFF.Users;

public sealed record LoginRequest(string Email, string Password);
