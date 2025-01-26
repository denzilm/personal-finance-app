using MediatR;
using PersonalFinanceApp.Application.Models.Authentication;

namespace PersonalFinanceApp.Application.Features.Users.Commands.LoginUser;

public sealed record LoginUserCommand(string Email, string Password) : IRequest<LoginResponse>;
