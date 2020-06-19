
using PoemInk.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PoemInk.Data
{
  public class PoemInkDbContext : IdentityDbContext<AppUser>
  {
    public PoemInkDbContext(DbContextOptions options)
      : base(options)
    {
    }

    public DbSet<Poet> Poets { get; set; }
    public DbSet<Poem> Poems { get; set; }
  }
}
