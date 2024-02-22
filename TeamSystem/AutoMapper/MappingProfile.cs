using AutoMapper;
using global::AutoMapper;
using TeamSystem.Models;
using TeamSystem.Models.DTOs;

namespace TeamSystem.AutoMapper
{
   
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentDTO, Student>();
            CreateMap<CourseDTO, Course>();
            CreateMap<StudentCourseDTO, StudentCourse>();
            // Add more mappings as needed
        }
    }

}
