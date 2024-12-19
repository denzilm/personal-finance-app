using PersonalFinanceApp.BFF.Users;

var builder = WebApplication.CreateBuilder(args);

var allowedOrigins =
    builder.Configuration["AllowedOrigins"] ?? throw new InvalidOperationException("Allowed origins is not configured");
var identityUrl =
    builder.Configuration["IdentityUrl"] ?? throw new InvalidOperationException("Identity URL is not configured");

builder.Services
    .AddHttpContextAccessor()
    .AddCors(options =>
    {
        options.AddPolicy("AppPolicy", policyBuilder =>
        {
            policyBuilder.WithOrigins(allowedOrigins.Split(","))
                .WithHeaders("Content-Type")
                .AllowCredentials();
        });
    });

builder.Services.AddHttpClient<IIdentityClient, IdentityClient>(client =>
{
    client.BaseAddress = new Uri(identityUrl);
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseExceptionHandler(applicationBuilder => applicationBuilder.Run(async context =>
{
    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
    await context.Response.WriteAsync("An unexpected fault occurred. Please try again later");
}));

app.UseRouting();
app.UseCors("AppPolicy");

app.MapUsers();

app.Run();