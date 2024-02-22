
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using TeamSystem.Models;
using TeamSystem.Models.DTOs;
using TeamSystem.RepositoryLayer;

namespace TeamSystem.ServiceLayer
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        public readonly IStudentRepository _studentRepository;
        public StudentService(IMapper mapper,IStudentRepository studentRepository)
        {
            _mapper = mapper;  
            _studentRepository = studentRepository;
        }
        public Task<OperationResponse> DeleteStudentById(long studentId)
        {
            if (_studentRepository.GetStudentById(studentId) == null)
            {
                return null;
            }
            else
            {
                return _studentRepository.DeleteStudentById(studentId);
            }
        }

        public Task<List<Student>> GetStudents()
        {
            return _studentRepository.GetStudents();
        }

        public Task<List<Student>> GetStudentsByCourseId(long courseId)
        {
            return _studentRepository.GetStudentsByCourseId(courseId);
        }

        public Task<Student> SaveStudent(StudentDTO studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            return _studentRepository.SaveStudent(student);
        }

        public Task<Student> UpdateStudent(long studentId, StudentDTO studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            if(_studentRepository.GetStudentById(studentId) == null)
            {
                return null;
            }
            else
            {
                return _studentRepository.UpdateStudent(studentId, student);
            }
        }
    }
}
