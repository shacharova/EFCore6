namespace EFCore6.Bal.Models.Students
{
    public class DeleteStudentBookBM
    {
        public uint StudentBookId { get; set; }

        public DeleteStudentBookBM(uint studentBookId)
        {
            StudentBookId = studentBookId;
        }
    }
}
