using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EFCore6.Dal.ValueGenerators;

namespace EFCore6.Dal.Models
{
    public class StudentBookDM
    {
        public uint? Id { get; set; }
        public uint? StudentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? Modified { get; set; }
        public DateTime? Created { get; set; }
    }

    public class StudentBookDMConfiguration : IEntityTypeConfiguration<StudentBookDM>
    {
        public void Configure(EntityTypeBuilder<StudentBookDM> builder)
        {
            builder.ToTable("students_books");
            builder.HasKey(dm => dm.Id);
            builder.HasIndex(dm => dm.StudentId).IsUnique(false);

            builder.Property(dm => dm.StudentId).IsRequired();
            builder.Property(dm => dm.Name).IsRequired()
                .HasDefaultValue("").ValueGeneratedOnAdd();
            builder.Property(dm => dm.Description)
                .HasDefaultValue("").ValueGeneratedOnAdd();
            builder.Property(dm => dm.ReleaseDate).IsRequired();
            builder.Property(dm => dm.Modified).IsRequired()
                .HasValueGenerator<UtcDateTimeGenerator>() // Only for In memory context
                .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
            builder.Property(dm => dm.Created).IsRequired()
                .HasValueGenerator<UtcDateTimeGenerator>() // Only for using In memory context
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();
        }
    }
}
