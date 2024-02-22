using System.ComponentModel.DataAnnotations;

namespace TeamSystem.Models.DTOs
{
    public class StudentCourseDTO
    {
        [Required(ErrorMessage = "StudentId is required")]
        public long StudentId { get; set; }
        [Required(ErrorMessage = "CourseId is required")]
        public long CourseId { get; set; }
    }
}
