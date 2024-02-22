using System.ComponentModel.DataAnnotations;

namespace TeamSystem.Models.DTOs
{
    public class StudentDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Range(18, 100)]
        public int Age { get; set; }
    }
}
