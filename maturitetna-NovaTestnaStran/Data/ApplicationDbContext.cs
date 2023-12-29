
using maturitetna_NovaTestnaStran.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace maturitetna_NovaTestnaStran.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ServerEntity> Servers { get; set; }
        public DbSet<DomainEntity> Domain { get; set; }
        public DbSet<UserDomainEntity> UserDomain { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
