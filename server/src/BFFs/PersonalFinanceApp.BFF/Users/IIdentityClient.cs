﻿namespace PersonalFinanceApp.BFF.Users;

public interface IIdentityClient
{
    Task<bool> RegisterUserAsync(RegisterRequest request);
}