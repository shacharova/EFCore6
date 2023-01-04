namespace EFCore6.Bal.Models.Students
{
    public class UpdateStudentBM
    {
        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }


        public UpdateStudentBM(uint id, string firstName, string? lastName, DateTime? birthDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }
    }
}
