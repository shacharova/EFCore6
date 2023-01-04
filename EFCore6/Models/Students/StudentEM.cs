namespace EFCore6.Models.Students
{
    public class StudentEM
    {
        public uint? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? Modified { get; set; }
        public DateTime? Created { get; set; }

        public IEnumerable<StudentBookEM>? Books { get; set; }
    }
}
