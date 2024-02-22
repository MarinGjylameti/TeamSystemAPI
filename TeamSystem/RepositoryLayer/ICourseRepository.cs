using TeamSystem.Models;
using TeamSystem.Models.DTOs;

namespace TeamSystem.RepositoryLayer
{
    public interface ICourseRepository
    {
        public Task<List<Course>> GetAllCourses();
        public Task<Course> SaveCourse(Course course);
        public Task<Course> UpdateCourse(long courseId,Course course);
        public Task<StudentCourse> SaveStudentCourse(StudentCourse studentCourse);
        public Task<Course> GetCourseById(long id);
    }
}
