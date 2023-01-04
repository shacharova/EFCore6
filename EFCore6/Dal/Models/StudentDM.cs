using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EFCore6.Dal.ValueGenerators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore6.Dal.Models
{
    // [Table("students")]
    public class StudentDM
    {
        // [Key]
        public uint? Id { get; set; }
        // [Column("first_name")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? Modified { get; set; }
        public DateTime? Created { get; set; }

        public IEnumerable<StudentBookDM>? Books { get; set; }
    }

    public class StudentDMConfiguration : IEntityTypeConfiguration<StudentDM>
    {
        public void Configure(EntityTypeBuilder<StudentDM> builder)
        {
            builder.ToTable("students");
            builder.HasKey(dm => dm.Id);

            builder.Property(dm => dm.FirstName).IsRequired().HasMaxLength(32);
            builder.Property(dm => dm.LastName).IsRequired()
                .HasDefaultValue("").ValueGeneratedOnAdd();
            builder.Property(dm => dm.BirthDate);
            builder.Property(dm => dm.Modified).IsRequired()
                .HasValueGenerator<UtcDateTimeGenerator>() // Only for In memory context
                .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
            builder.Property(dm => dm.Created).IsRequired()
                .HasValueGenerator<UtcDateTimeGenerator>() // Only for using In memory context
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.HasMany(dm => dm.Books).WithOne().HasForeignKey(dm => dm.StudentId);
        }
    }

    
}
