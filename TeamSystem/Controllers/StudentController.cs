using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamSystem.Data;
using TeamSystem.Models;
using TeamSystem.Models.DTOs;
using TeamSystem.ServiceLayer;

namespace TeamSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        public readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await _studentService.GetStudents());
        }


        [HttpGet]
        [Route("course/{ID}")]
        public async Task<IActionResult> GetStudentsByCourse(long ID)
        {
            var studentsInCourse = await _studentService.GetStudentsByCourseId(ID);
            if (studentsInCourse == null)
            {
                return NotFound("STUDENTS NOT FOUND");
            }
            else
            {
                return Ok(studentsInCourse);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddStudents(StudentDTO model)
        {
            var student = _studentService.SaveStudent(model);
            if (student == null)
            {
                return BadRequest("ERROR WHILE SAVING STUDENT");
            }
            else
            {
                return Ok(student);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] long id, StudentDTO model)
        {
            var student = _studentService.UpdateStudent(id, model);
            if (student == null)
            {
                return NotFound("STUDENT NOT FOUND");
            }
            else
            {
                return Ok("STUDENT UPDATED SUCCESSFULLY");
            }
        }


        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteStudents(long ID)
        {
            var response = await _studentService.DeleteStudentById(ID);
            if (response.IsSuccess)
            {
                return Ok(response.Message);
            }
            else
            {
                return NotFound(response.Message);
            }
        }

    }
}