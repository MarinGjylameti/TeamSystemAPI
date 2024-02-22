using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TeamSystem.Models
{
    public class Student
    {
        [Key] // This marks the id property as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //
        public long id {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }
}
