using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Minions.Models;

namespace Minions.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Minions.Models.Minion> Minion { get; set; }
        public DbSet<Minions.Models.Plan> Plan { get; set; }
    }
}