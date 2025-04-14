using Api.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Presistence.Configurations;

namespace Presistence
{
    public class RepositoryDbContext : IdentityDbContext<User>
    {
        public RepositoryDbContext(DbContextOptions options) : base(options) // will get DbContextOptions from CreateDbContext method
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
        }
        
    }
}
