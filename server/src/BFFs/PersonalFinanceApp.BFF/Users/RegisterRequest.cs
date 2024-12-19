﻿namespace PersonalFinanceApp.BFF.Users;

public sealed record RegisterRequest(
    string FirstName, string LastName, string Email, string Password, string ConfirmPassword);