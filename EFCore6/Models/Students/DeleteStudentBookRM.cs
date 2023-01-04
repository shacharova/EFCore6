using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EFCore6.Models.Students
{
    public class DeleteStudentBookRM
    {
        [Required, NotNull]
        public uint? StudentBookId { get; set; }
    }
}
