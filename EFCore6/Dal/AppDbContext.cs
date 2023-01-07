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

            /* 
            var studentBuilder = modelBuilder.Entity<StudentDM>();
            studentBuilder.ToTable("students");
            studentBuilder.HasKey(dm => dm.Id);

            studentBuilder.Property(dm => dm.FirstName).IsRequired().HasMaxLength(32);
            studentBuilder.Property(dm => dm.LastName).IsRequired().HasMaxLength(32)
                .HasDefaultValue("").ValueGeneratedOnAdd();
            studentBuilder.Property(dm => dm.BirthDate);
            studentBuilder.Property(dm => dm.Modified).IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                .HasValueGenerator<UtcDateTimeGenerator>() // Only for In memory context
                .ValueGeneratedOnAddOrUpdate();
            studentBuilder.Property(dm => dm.Created).IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasValueGenerator<UtcDateTimeGenerator>() // Only for using In memory context
                .ValueGeneratedOnAddOrUpdate();

            studentBuilder.HasMany(dm => dm.Books).WithOne().HasForeignKey(dm => dm.StudentId);
            */
        }

    }
}
