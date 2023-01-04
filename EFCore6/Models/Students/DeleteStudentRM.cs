using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EFCore6.Models.Students
{
    public class DeleteStudentRM
    {
        [Required, NotNull]
        public uint? Id { get; set; }
    }
}
