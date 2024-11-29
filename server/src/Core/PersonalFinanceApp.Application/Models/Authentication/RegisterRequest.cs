namespace PersonalFinanceApp.Application.Models.Authentication;

public sealed record RegisterRequest(string FirstName, string LastName, string Email, string Password);
