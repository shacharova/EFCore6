using AutoMapper;
using EFCore6.Bal.Models.Students;
using EFCore6.Dal.Models;
using EFCore6.Models.Students;

namespace EFCore6.Bal
{
    public class StudentsMaps : Profile
    {
        public StudentsMaps()
        {
            #region Mapping of RMs to BMs
            CreateMap<CreateStudentRM, CreateStudentBM>()
                .ConstructUsing(s => new CreateStudentBM(s.FirstName)) // TODO: Get UserId from injected service + also to Guid
                .ForMember(d => d.LastName, m => m.MapFrom(s => s.LastName))
                .ForMember(d => d.BirthDate, m => m.MapFrom(s => s.BirthDate));

            CreateMap<UpdateStudentRM, UpdateStudentBM>()
                .ConstructUsing(s => new UpdateStudentBM(s.Id.Value, s.FirstName, s.LastName, s.BirthDate));

            CreateMap<DeleteStudentRM, DeleteStudentBM>()
                .ConstructUsing(s => new DeleteStudentBM(s.Id.Value));

            CreateMap<CreateStudentBookRM, CreateStudentBookBM>()
                .ConstructUsing(s => new CreateStudentBookBM(s.StudentId.Value, s.Name, s.Description))
                .ForMember(d => d.ReleaseDate, m => m.MapFrom(s => s.ReleaseDate));

            CreateMap<DeleteStudentBookRM, DeleteStudentBookBM>()
                .ConstructUsing(s => new DeleteStudentBookBM(s.StudentBookId.Value));
            #endregion


            #region Mapping of BMs to DMs (Used for: Create new db record)
            CreateMap<CreateStudentBM, StudentDM>()
                .ForMember(dest => dest.FirstName, m => m.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, m => m.MapFrom(src => src.LastName))
                .ForMember(dest => dest.BirthDate, m => m.MapFrom(src => src.BirthDate))
                .ForMember(d => d.Books, m => m.MapFrom(src => new List<StudentBookDM>()));

            CreateMap<CreateStudentBookBM, StudentBookDM>()
                .ForMember(d => d.StudentId, m => m.MapFrom(s => s.StudentId))
                .ForMember(d => d.Name, m => m.MapFrom(s => s.Name))
                .ForMember(d => d.Description, m => m.MapFrom(s => s.Description))
                .ForMember(d => d.ReleaseDate, m => m.MapFrom(s => s.ReleaseDate));
            #endregion


            #region Mapping of DMs to EMs
            CreateMap<StudentDM, StudentEM>()
                .ForMember(d => d.Id, m => m.MapFrom(s => s.Id))
                .ForMember(d => d.FirstName, m => m.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, m => m.MapFrom(s => s.LastName))
                .ForMember(d => d.BirthDate, m => m.MapFrom(s => s.BirthDate))
                .ForMember(d => d.Modified, m => m.MapFrom(s => s.Modified))
                .ForMember(d => d.Created, m => m.MapFrom(s => s.Created))
                .ForMember(d => d.Books, m => m.MapFrom(s => s.Books));

            CreateMap<StudentBookDM, StudentBookEM>()
                .ForMember(d => d.Id, m => m.MapFrom(s => s.Id))
                .ForMember(d => d.StudentId, m => m.MapFrom(s => s.StudentId))
                .ForMember(d => d.Name, m => m.MapFrom(s => s.Name))
                .ForMember(d => d.Description, m => m.MapFrom(s => s.Description))
                .ForMember(d => d.ReleaseDate, m => m.MapFrom(s => s.ReleaseDate))
                .ForMember(d => d.Modified, m => m.MapFrom(s => s.Modified))
                .ForMember(d => d.Created, m => m.MapFrom(s => s.Created));
            #endregion


            #region Mapping of BMs to 3rd party RMs or External RMs

            #endregion
        }
    }
}
