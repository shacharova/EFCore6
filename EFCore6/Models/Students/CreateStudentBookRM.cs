using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EFCore6.Models.Students
{
    public class CreateStudentBookRM
    {
        [Required, NotNull]
        public uint? StudentId { get; set; }

        [Required(AllowEmptyStrings = false), NotNull]
        public string? Name { get; set; }

        [Required(AllowEmptyStrings = true), NotNull]
        public string? Description { get; set; }

        public DateTime? ReleaseDate { get; set; }
    }
}
