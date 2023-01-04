using Microsoft.EntityFrameworkCore;
using EFCore6.Dal.Models;
using System.Reflection;

namespace EFCore6.Dal
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

#nullable disable
        public DbSet<StudentDM> Students { get; set; }
        public DbSet<StudentBookDM> StudentsBooks { get; set; }
#nullable restore


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase(databaseName: "AppDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
