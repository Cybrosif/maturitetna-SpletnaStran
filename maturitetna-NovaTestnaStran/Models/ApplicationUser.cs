using maturitetna_NovaTestnaStran.Models;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata;

public class ApplicationUser : IdentityUser
{
    public List<UserDomainEntity> Domain { get; set; }
}
