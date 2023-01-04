using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using EFCore6.Bal;
using EFCore6.Bal.Models.Students;
using EFCore6.Models.Students;

namespace EFCore6.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentsController : ControllerBase
    {
        private StudentsBal Bal { get; }
        private IMapper Mapper { get; }

        public StudentsController(StudentsBal studentsBal, IMapper mapper)
        {
            Bal = studentsBal;
            Mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync(CreateStudentRM request, CancellationToken cancellationToken)
        {
            CreateStudentBM requstBM = Mapper.Map<CreateStudentBM>(request);
            StudentEM? studentEM = null;
            try
            {
                studentEM = await Bal.CreateStudentAsync(requstBM, cancellationToken);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", $"Failed to create student - {ex.Message}");
            }
            return ModelState.IsValid ? Ok(studentEM) : BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentsAsync(CancellationToken cancellationToken)
        {
            List<StudentEM>? studentsEM = null;
            try
            {
                studentsEM = await Bal.ReadAllStudentsAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Failed to read all students - {ex.Message}");
            }
            return ModelState.IsValid ? Ok(studentsEM) : BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStudentAsync(UpdateStudentRM request, CancellationToken cancellationToken)
        {
            UpdateStudentBM requstBM = Mapper.Map<UpdateStudentBM>(request);
            StudentEM? studentEM = null;
            try
            {
                studentEM = await Bal.UpdateStudentAsync(requstBM, cancellationToken);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Failed to update student - {ex.Message}");
            }
            return ModelState.IsValid ? Ok(studentEM) : BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudentAsync(DeleteStudentRM request, CancellationToken cancellationToken)
        {
            DeleteStudentBM requstBM = Mapper.Map<DeleteStudentBM>(request);
            int deletedCount = 0;
            try
            {
                deletedCount = await Bal.DeleteStudentAsync(requstBM, cancellationToken);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Failed to delete student - {ex.Message}");
            }
            return ModelState.IsValid ? Ok(deletedCount) : BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentBookAsync(CreateStudentBookRM request, CancellationToken cancellationToken)
        {
            CreateStudentBookBM requstBM = Mapper.Map<CreateStudentBookBM>(request);
            StudentBookEM? studentBookEM = null;
            try
            {
                studentBookEM = await Bal.CreateStudentBookAsync(requstBM, cancellationToken);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Failed to create student's book - {ex.Message}");
            }
            return ModelState.IsValid ? Ok(studentBookEM) : BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudentBookAsync(DeleteStudentBookRM request, CancellationToken cancellationToken)
        {
            DeleteStudentBookBM requstBM = Mapper.Map<DeleteStudentBookBM>(request);
            int deletedCount = 0;
            try
            {
                deletedCount = await Bal.DeleteStudentBookAsync(requstBM, cancellationToken);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Failed to delete student's book - {ex.Message}");
            }
            return ModelState.IsValid ? Ok(deletedCount) : BadRequest(ModelState);
        }
    }
}