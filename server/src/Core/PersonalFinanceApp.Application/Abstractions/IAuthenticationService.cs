using PersonalFinanceApp.Application.Models.Authentication;

namespace PersonalFinanceApp.Application.Abstractions;

public interface IAuthenticationService
{
    Task RegisterAsync(RegisterRequest request);
}
