using System.ComponentModel.DataAnnotations;

namespace TeamSystem.Models.DTOs
{
    public class CourseDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public long MaxNumberOfStudents { get; set; }
    }
}
