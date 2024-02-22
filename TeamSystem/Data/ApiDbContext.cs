using Microsoft.EntityFrameworkCore;
using TeamSystem.Models;

namespace TeamSystem.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Student> Students  { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Course>().HasNoKey();
        //    modelBuilder.Entity<Student>().HasNoKey();
        //}
    }

}
