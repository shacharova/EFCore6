using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EFCore6.Models.Students
{
    public class UpdateStudentRM
    {
        [Required, NotNull]
        public uint? Id { get; set; }

        [Required, NotNull]
        public string? FirstName { get; set; }

        [Required(AllowEmptyStrings = true), NotNull]
        public string? LastName { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
