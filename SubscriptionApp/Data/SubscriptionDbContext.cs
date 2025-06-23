using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SubscriptionApp.Data
{
    public class SubscriptionDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public SubscriptionDbContext(DbContextOptions<SubscriptionDbContext> options)
            : base(options)
        {
        }

        public DbSet<SubscriptionApp.Models.Service> Services { get; set; }
    }
}