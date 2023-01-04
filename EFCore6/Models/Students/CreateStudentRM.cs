using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EFCore6.Models.Students
{
    public class CreateStudentRM
    {
        [Required, MinLength(2), MaxLength(32), NotNull]
        public string? FirstName { get; set; }

        [MinLength(2), MaxLength(32)]
        public string? LastName { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
