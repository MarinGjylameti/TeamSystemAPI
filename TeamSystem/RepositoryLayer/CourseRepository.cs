using Microsoft.AspNetCore.Http.HttpResults;
using TeamSystem.Data;
using TeamSystem.Models;
using TeamSystem.Models.DTOs;

namespace TeamSystem.RepositoryLayer
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApiDbContext _db;
        public CourseRepository(ApiDbContext db)
        {
            _db = db;  
        }
        public Task<List<Course>> GetAllCourses()
        {
            var courses = _db.Courses.ToList();
            return Task.FromResult(courses);
        }

        public Task<Course> GetCourseById(long id)
        {
            var course = _db.Courses.FirstOrDefault(x => x.Code == id);
            return Task.FromResult(course);
        }

        public Task<Course> SaveCourse(Course course)
        {
            try
            {
                _db.Courses.Add(course);
                _db.SaveChanges();
                return Task.FromResult(course);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<StudentCourse> SaveStudentCourse(StudentCourse studentCourse)
        {
            try
            {
                var CheckIfStudentIDExist = _db.Students.FirstOrDefault(x => x.id == studentCourse.StudentId);
                var CheckIfCourseIDExist = _db.Courses.FirstOrDefault(x => x.Code == studentCourse.CourseId);
                if (CheckIfStudentIDExist!= null && CheckIfCourseIDExist != null)
                {
                    var exist = _db.StudentCourses.FirstOrDefault(x => x.CourseId == studentCourse.CourseId && x.StudentId == studentCourse.StudentId);
                    if (exist == null)
                    {
                        _db.StudentCourses.Add(studentCourse);
                        _db.SaveChanges();
                        return Task.FromResult(studentCourse);
                    }
                    else
                    {
                        return Task.FromResult(exist);
                    }
                }
                else
                {
                    return Task.FromResult(new StudentCourse() { StudentId = -1 , CourseId = -1});
                }
                
            }
            catch (Exception)
            {
                return Task.FromResult(new StudentCourse());
            }
        }

        public Task<Course> UpdateCourse(long courseId, Course course)
        {
            try
            {
                var cours = _db.Courses.FirstOrDefault(x => x.Code == courseId);
                cours.Name = course.Name;
                cours.MaxNumberOfStudents = course.MaxNumberOfStudents;
                _db.SaveChanges();
                return Task.FromResult(cours);
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
