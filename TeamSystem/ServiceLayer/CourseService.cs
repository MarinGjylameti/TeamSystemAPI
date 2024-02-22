using AutoMapper;
using TeamSystem.Models;
using TeamSystem.Models.DTOs;
using TeamSystem.RepositoryLayer;

namespace TeamSystem.ServiceLayer
{
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        public readonly ICourseRepository _courseRepository;
        public CourseService(IMapper mapper, ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<List<Course>> GetAllCourses()
        {
            return await _courseRepository.GetAllCourses();
        }

        public async Task<Course> SaveCourse(CourseDTO _course)
        {
           var course = _mapper.Map<Course>(_course);
           return await _courseRepository.SaveCourse(course);
        }

        public async Task<StudentCourse> SaveStudentCourse(StudentCourseDTO _studentCourse)
        {
            var studentCourse = _mapper.Map<StudentCourse>(_studentCourse);
            return await _courseRepository.SaveStudentCourse(studentCourse);
        }

        public async Task<Course> UpdateCourse(long courseId, CourseDTO _course)
        {
            var course = _mapper.Map<Course>(_course);
            if(_courseRepository.GetCourseById(courseId) == null)
            {
                return null;
            }
            else
            {
                return await _courseRepository.UpdateCourse(courseId, course);
            }
        }
    }
}
