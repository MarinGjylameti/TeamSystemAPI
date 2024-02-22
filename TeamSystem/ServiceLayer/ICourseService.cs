using TeamSystem.Models;
using TeamSystem.Models.DTOs;

namespace TeamSystem.ServiceLayer
{
    public interface ICourseService
    {
        public Task<List<Course>> GetAllCourses();
        public Task<Course> SaveCourse(CourseDTO course);
        public Task<Course> UpdateCourse(long courseId,CourseDTO course);
        public Task<StudentCourse> SaveStudentCourse(StudentCourseDTO studentCourse);
    }
}
