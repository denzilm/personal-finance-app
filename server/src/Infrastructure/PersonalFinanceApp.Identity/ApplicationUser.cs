using Microsoft.AspNetCore.Identity;

namespace PersonalFinanceApp.Identity;

public sealed class ApplicationUser : IdentityUser
{
    public ApplicationUser(string firstName, string lastName, byte[] avatar)
    {
        FirstName = firstName;
        LastName = lastName;
        Avatar = avatar;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public byte[] Avatar { get; private set; }
}
