
using PoemInk.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace PoemInk.Data
{
  public class PoemInkDbContext : IdentityDbContext<AppUser>
  {
    public PoemInkDbContext(DbContextOptions options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Poet>(entity => {
            entity.HasIndex(e => e.PenName).IsUnique();
        });
        builder.Ignore <IdentityUserLogin<string>>();
        builder.Ignore<IdentityUserRole<string>>();
        builder.Ignore<IdentityUserClaim<string>>();
        builder.Ignore<IdentityUserToken<string>>();
    }

    public DbSet<Poet> Poets { get; set; }
    public DbSet<Poem> Poems { get; set; }
  }
}
