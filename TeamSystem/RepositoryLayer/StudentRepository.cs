
using TeamSystem.Data;
using TeamSystem.Models;

namespace TeamSystem.RepositoryLayer
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApiDbContext _db;
        public StudentRepository(ApiDbContext db)
        {
            _db = db;
        }
        public Task<OperationResponse> DeleteStudentById(long studentId)
        {
            try
            {
                _db.Students.Remove(_db.Students.FirstOrDefault(x => x.id == studentId));
                _db.StudentCourses.RemoveRange(_db.StudentCourses.Where(x=>x.StudentId == studentId));
                _db.SaveChanges();
                return Task.FromResult(new OperationResponse() { IsSuccess = false, Message = "STUDENT DELETED" });
            }
            catch (Exception e)
            {
                return Task.FromResult(new OperationResponse() {IsSuccess = false,Message = e.Message });
            }
        }

        public Task<Student> GetStudentById(long id)
        {
            var student = _db.Students.FirstOrDefault(x => x.id == id);
            return Task.FromResult(student);
        }

        public Task<List<Student>> GetStudents()
        {
            var student = _db.Students.ToList();
            return Task.FromResult(student);
        }

        public Task<List<Student>> GetStudentsByCourseId(long courseId)
        {
            var studentIds = _db.StudentCourses.Where(y => y.CourseId == courseId).ToList();
            List<Student> students = new List<Student>();
            foreach (var item in studentIds)
            {
                students.Add(_db.Students.FirstOrDefault(x => x.id == item.StudentId));
            }
            return Task.FromResult(students);
        }

        public Task<Student> SaveStudent(Student student)
        {
            try
            {
                _db.Students.Add(student);
                _db.SaveChanges();
                return Task.FromResult(student);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<Student> UpdateStudent(long studentId, Student student)
        {
            try
            {
                var studenti = _db.Students.FirstOrDefault(x=>x.id == studentId);
                studenti.Email = student.Email;
                studenti.FirstName = student.FirstName;
                studenti.LastName = student.LastName;
                studenti.Age = student.Age;
                studenti.Gender = student.Gender;
                _db.SaveChanges();
                return Task.FromResult(student);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
