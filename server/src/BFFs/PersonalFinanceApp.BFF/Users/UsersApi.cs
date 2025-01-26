using Microsoft.AspNetCore.Http.HttpResults;
using PersonalFinanceApp.BFF.Services;

namespace PersonalFinanceApp.BFF.Users;

public static class UsersApi
{
    public static RouteGroupBuilder MapUsers(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("users");

        group.MapPost("login",
            async (LoginRequest request, IIdentityClient identityClient, ISignInManager signInManager) =>
            {
                var (accessToken, refreshToken) = await identityClient.LoginAsync(request);
                await signInManager.SignInAsync(accessToken, refreshToken);
            });

        group.MapPost("register",
            async Task<Results<Ok, ValidationProblem>> (RegisterRequest request, IIdentityClient identityClient) =>
            {
                var registered = await identityClient.RegisterUserAsync(request);
                if (registered)
                    return TypedResults.Ok();

                return TypedResults.ValidationProblem(new Dictionary<string, string[]>
                {
                    { "DuplicateUser", ["Registration Failed. The user already exists"] }
                });
            });

        return group;
    }
}
