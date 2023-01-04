namespace EFCore6.Bal.Models.Students
{
    public class CreateStudentBM
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public CreateStudentBM(string firstName)
        {
            FirstName = firstName;
        }
    }
}
