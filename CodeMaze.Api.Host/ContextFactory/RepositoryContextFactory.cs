using CodeMaze.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CodeMaze.Api.Host.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        //With the RepositoryContextFactory class,
        //which implements the IDesignTimeDbContextFactory interface,
        //we have registered our RepositoryContext class at design time.
        //This helps us find the RepositoryContext class
        //in another project while executing migrations.
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            //Migration assembly is not in Host project, but in the Repository project.
            //So, we’ve just changed the project for the migration assembly.

            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("CodeMaze.Api.Host"));

            return new RepositoryContext(builder.Options);
        }
    }
}
