using AutoMapper;

using WebApplication1.Entities;

namespace WebApplication1.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();


            CreateMap<Student, PersonDto>();
            //CreateMap<Person, PersonDto>().Include<Student, PersonDto>().ForMember(o => o.FirstMidName, m => m.Ignore());
            CreateMap<Person, PersonDto>().Include<Student, PersonDto>();

           

            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
        }

    }
}

