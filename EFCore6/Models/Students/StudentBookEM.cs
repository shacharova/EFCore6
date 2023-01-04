namespace EFCore6.Models.Students
{
    public class StudentBookEM
    {
        public uint? Id { get; set; }
        public uint? StudentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? Modified { get; set; }
        public DateTime? Created { get; set; }
    }
}
