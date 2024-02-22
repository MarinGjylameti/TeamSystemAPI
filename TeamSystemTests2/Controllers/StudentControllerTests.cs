using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamSystem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TeamSystem.Models.DTOs;
using TeamSystem.Models;
using TeamSystem.ServiceLayer;
using Xunit;
using Assert = Xunit.Assert;

namespace TeamSystem.Controllers.Tests
{
    [TestClass()]
    public class StudentControllerTests
    {
        [Fact]
        [TestMethod()]
        public async Task ConnectCourseToStudent_ReturnsOk_WithValidData()
        {
            // Arrange
            var mockCourseService = new Mock<ICourseService>();
            var testStudentCourseDto = new StudentCourseDTO { StudentId = 1, CourseId = 1 }; 
            var mappedStudentCourse = new StudentCourse { StudentId = 1, CourseId = 1 }; 

            mockCourseService.Setup(x => x.SaveStudentCourse(It.IsAny<StudentCourseDTO>()))
                             .ReturnsAsync(mappedStudentCourse);

            var controller = new CourseController(mockCourseService.Object);

            // Act
            var result = await controller.ConnectCourseToStudent(testStudentCourseDto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        [TestMethod()]
        public async Task DeleteStudent_ReturnsOk_WhenStudentExists()
        {
            // Arrange
            var mockStudentService = new Mock<IStudentService>();
            var studentId = 1;
            mockStudentService.Setup(service => service.DeleteStudentById(studentId))
                              .ReturnsAsync(new OperationResponse { IsSuccess = true, Message = "STUDENT DELETED" });

            var controller = new StudentController(mockStudentService.Object);

            // Act
            var result = await controller.DeleteStudents(studentId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("STUDENT DELETED", okResult.Value);
        }

        [Fact]
        [TestMethod()]
        public async Task DeleteStudent_ReturnsNotFound_WhenStudentDoesNotExist()
        {
           
            var mockStudentService = new Mock<IStudentService>();
            var nonExistentStudentId = 999;
            mockStudentService.Setup(service => service.DeleteStudentById(nonExistentStudentId))
                              .ReturnsAsync(new OperationResponse { IsSuccess = false, Message = "STUDENT NOT FOUND" });

            var controller = new StudentController(mockStudentService.Object);

            
            var result = await controller.DeleteStudents(nonExistentStudentId);

            
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("STUDENT NOT FOUND", notFoundResult.Value);
        }

    }
}