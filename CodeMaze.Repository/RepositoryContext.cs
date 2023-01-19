using CodeMaze.Entities.Models;
using CodeMaze.Repository.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeMaze.Repository
{
    //public class RepositoryContext : DbContext
    public class RepositoryContext : IdentityDbContext<User>
    {
        //RepositoryContext class now inherits from the IdentityDbContext class
        //and not DbContext because we want to integrate our context with Identity.
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Required for migration to work properly.
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Company>? Companies { get; set; }

        public DbSet<Employee>? Employees { get; set; }
    }
}
