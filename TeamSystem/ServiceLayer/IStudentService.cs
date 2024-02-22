using TeamSystem.Models;
using TeamSystem.Models.DTOs;

namespace TeamSystem.ServiceLayer
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudents();
        public Task<Student> SaveStudent(StudentDTO student);
        public Task<List<Student>> GetStudentsByCourseId(long courseId);
        public Task<Student> UpdateStudent(long studentId, StudentDTO student);
        public Task<OperationResponse> DeleteStudentById(long studentId);
    } 
}
