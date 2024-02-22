using TeamSystem.Models;

namespace TeamSystem.RepositoryLayer
{
    public interface IStudentRepository
    {
        public Task<List<Student>> GetStudents();
        public Task<Student> GetStudentById(long id);
        public Task<Student> SaveStudent(Student student);
        public Task<List<Student>> GetStudentsByCourseId(long courseId);
        public Task<Student> UpdateStudent(long studentId,Student student);
        public Task<OperationResponse> DeleteStudentById(long studentId);
    } 
}
