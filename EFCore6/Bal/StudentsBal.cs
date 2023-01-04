using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EFCore6.Bal.Models.Students;
using EFCore6.Dal;
using EFCore6.Dal.Models;
using EFCore6.Models.Students;
using System.Threading;

namespace EFCore6.Bal
{
    public class StudentsBal
    {
        private AppDbContext AppDb { get; }
        private IMapper Mapper { get; }

        public StudentsBal(AppDbContext appDbContext, IMapper mapper)
        {
            AppDb = appDbContext;
            Mapper = mapper;
        }


        public async Task<StudentEM> CreateStudentAsync(CreateStudentBM request, CancellationToken cancellationToken)
        {
            StudentDM studentDM = Mapper.Map<StudentDM>(request);
            //studentDM.Books = new List<StudentBookDM>();

            await AppDb.Students.AddAsync(studentDM, cancellationToken);
            await AppDb.SaveChangesAsync(cancellationToken);
            return Mapper.Map<StudentEM>(studentDM);
        }

        public async Task<List<StudentEM>> ReadAllStudentsAsync(CancellationToken cancellationToken)
        {
            IQueryable<StudentDM> query = AppDb.Students.Include(dm => dm.Books);
            List<StudentDM> studentsDM = await query.ToListAsync(cancellationToken);
            return Mapper.Map<List<StudentEM>>(studentsDM);
        }
        public async Task<List<StudentEM>> ReadStudentsWithFiltersAsync(CancellationToken cancellationToken)
        {
            IQueryable<StudentDM> query = AppDb.Students.Include(dm => dm.Books);

            query = query.Where(dm => dm.Books != null && dm.Books.Any());
            query = query.OrderBy(dm => dm.FirstName);

            List<StudentDM> studentsDM = await query.ToListAsync(cancellationToken);
            return Mapper.Map<List<StudentEM>>(studentsDM);
        }

        public async Task<StudentEM> UpdateStudentAsync(UpdateStudentBM request, CancellationToken cancellationToken)
        {
            IQueryable<StudentDM> query = AppDb.Students.Where(s => s.Id == request.Id);
            StudentDM? studentDM = await query.SingleOrDefaultAsync(cancellationToken);
            if (studentDM == null)
                throw new KeyNotFoundException();

            studentDM.FirstName = request.FirstName;
            studentDM.LastName = request.LastName;
            studentDM.BirthDate = request.BirthDate;
            await AppDb.SaveChangesAsync(cancellationToken);
            return Mapper.Map<StudentEM>(studentDM);
        }

        public async Task<int> DeleteStudentAsync(DeleteStudentBM request, CancellationToken cancellationToken)
        {
            IQueryable<StudentDM> query = AppDb.Students.Where(s => s.Id == request.Id);

            StudentDM? studentDM = await query.SingleOrDefaultAsync(cancellationToken);
            if (studentDM == null)
                throw new KeyNotFoundException();

            AppDb.Students.Remove(studentDM);
            return await AppDb.SaveChangesAsync(cancellationToken);
        }

        public async Task<StudentBookEM> CreateStudentBookAsync(CreateStudentBookBM request, CancellationToken cancellationToken)
        {
            StudentBookDM studentBookDM = Mapper.Map<StudentBookDM>(request);

            await AppDb.StudentsBooks.AddAsync(studentBookDM, cancellationToken);
            await AppDb.SaveChangesAsync(cancellationToken);
            return Mapper.Map<StudentBookEM>(studentBookDM);
        }

        public async Task<int> DeleteStudentBookAsync(DeleteStudentBookBM request, CancellationToken cancellationToken)
        {
            IQueryable<StudentBookDM> query = AppDb.StudentsBooks.Where(s => s.Id == request.StudentBookId);

            StudentBookDM? studentBookDM = await query.SingleOrDefaultAsync(cancellationToken);
            if (studentBookDM == null)
                throw new KeyNotFoundException();

            AppDb.StudentsBooks.Remove(studentBookDM);
            return await AppDb.SaveChangesAsync(cancellationToken);
        }
    }
}
