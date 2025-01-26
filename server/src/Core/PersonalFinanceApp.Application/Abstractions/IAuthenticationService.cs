using PersonalFinanceApp.Application.Models.Authentication;

namespace PersonalFinanceApp.Application.Abstractions;

public interface IAuthenticationService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
    Task RegisterAsync(RegisterRequest request);
}
