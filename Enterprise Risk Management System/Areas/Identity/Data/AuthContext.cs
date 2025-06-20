using ERMS.DL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ERMS.DAL.Auth;

public class AuthContext : IdentityDbContext<IdentityAuthUserModel>
{
    public AuthContext(DbContextOptions<AuthContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<IdentityAuthUserModel>().Property(u => u.address).HasMaxLength(256);
        builder.HasDefaultSchema("identity");
    }

}
