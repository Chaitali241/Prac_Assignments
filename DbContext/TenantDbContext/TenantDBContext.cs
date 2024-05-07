using Microsoft.EntityFrameworkCore;
using Prac_assignments.Model;

namespace Prac_assignments.TenantDbContext
{
    public class TenantDBContext : DbContext
    {
        public TenantDBContext(DbContextOptions<TenantDBContext> options) : base(options) { }

        public DbSet<UserProfile> UserProfile { get; set; }
    }
}
