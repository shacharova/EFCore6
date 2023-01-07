using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EFCore6.Dal.ValueGenerators;

namespace EFCore6.Dal.Models
{
    // [Table("students")]
    public class StudentDM
    {
        // [Key]
        public uint? Id { get; set; }

        // [Column("first_name"), Required, MaxLength(32)]
        public string? FirstName { get; set; }

        // [Column("last_name"), Required, MaxLength(32)]
        // [DefaultValue(""), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? LastName { get; set; }

        // [Column("birth_date")]
        public DateTime? BirthDate { get; set; }

        // [Column("modified"), Required]
        public DateTime? Modified { get; set; }

        // [Column("created"), Required]
        public DateTime? Created { get; set; }


        // [ForeignKey(nameof(StudentBookDM.StudentId))]
        public IEnumerable<StudentBookDM>? Books { get; set; }
    }

    public class StudentDMConfiguration : IEntityTypeConfiguration<StudentDM>
    {
        public void Configure(EntityTypeBuilder<StudentDM> builder)
        {
            builder.ToTable("students");
            builder.HasKey(dm => dm.Id);

            builder.Property(dm => dm.FirstName).IsRequired().HasMaxLength(32);
            builder.Property(dm => dm.LastName).IsRequired().HasMaxLength(32)
                .HasDefaultValue("").ValueGeneratedOnAdd();
            builder.Property(dm => dm.BirthDate);
            builder.Property(dm => dm.Modified).IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                .HasValueGenerator<UtcDateTimeGenerator>() // Only for In memory context
                .ValueGeneratedOnAddOrUpdate();
            builder.Property(dm => dm.Created).IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasValueGenerator<UtcDateTimeGenerator>() // Only for using In memory context
                .ValueGeneratedOnAddOrUpdate();

            builder.HasMany(dm => dm.Books).WithOne().HasForeignKey(dm => dm.StudentId);
        }
    }


}
