using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Presistence;

namespace Ecommerce.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryDbContext>
    {
        public RepositoryDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
                   .Build();

            var builder = new DbContextOptionsBuilder<RepositoryDbContext>()
                .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                b => b.MigrationsAssembly("Presistence"));

            return new RepositoryDbContext(builder.Options); // will be executed automatically
        }
    }
}
