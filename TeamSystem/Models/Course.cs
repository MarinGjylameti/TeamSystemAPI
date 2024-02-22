using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TeamSystem.Models
{
    public class Course
    {
        [Key] // This marks the id property as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //
        public long Code { get; set; }
        public string Name { get; set; }
        public long MaxNumberOfStudents { get; set; }
    }
}
