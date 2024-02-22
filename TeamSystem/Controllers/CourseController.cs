using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamSystem.Data;
using TeamSystem.Models;
using TeamSystem.Models.DTOs;
using TeamSystem.RepositoryLayer;
using TeamSystem.ServiceLayer;

namespace TeamSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        public readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var res = await _courseService.GetAllCourses();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourses(CourseDTO model)
        {

            if (ModelState.IsValid)
            {
                var course = _courseService.SaveCourse(model);
                return Ok(course);
            }
            else
            {
                return BadRequest("ERROR WHILE SAVING COURSE");
            }
        }

        [HttpPost("/ConnectCourseToStudent")]
        public async Task<IActionResult> ConnectCourseToStudent(StudentCourseDTO model)
        {
            if (ModelState.IsValid)
            {
                var studentCourse = _courseService.SaveStudentCourse(model);
                if (studentCourse != null && studentCourse.Result.StudentId != -1)
                {
                    return Ok(studentCourse);
                }
                else
                {
                    return BadRequest("ERROR WHILE CONNECTING STUDENT TO COURSE");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
              
            
            
        }
        [HttpPut]
        [Route("{code}")]
        public async Task<IActionResult> UpdateCourses([FromRoute] long code, CourseDTO model)
        {
            var course = _courseService.UpdateCourse(code, model);
            if (course == null)
            {
                return NotFound("COURSE NOT FOUND");
            }
            else
            {
                return Ok("COURSE UPDATED SUCCESSFULLY");
            }
        }
    }
}
