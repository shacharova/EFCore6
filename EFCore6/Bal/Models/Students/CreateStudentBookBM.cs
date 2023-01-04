namespace EFCore6.Bal.Models.Students
{
    public class CreateStudentBookBM
    {
        public uint StudentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public CreateStudentBookBM(uint studentId, string name, string description)
        {
            StudentId = studentId;
            Name = name;
            Description = description;
        }
    }
}
