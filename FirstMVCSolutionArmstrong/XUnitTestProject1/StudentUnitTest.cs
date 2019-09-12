using System;
using System.Collections.Generic;
using System.Text;
using FirstMVCAppArmstrong.Models;
using Xunit;

namespace XUnitTestProject1
{
    public class StudentUnitTest
    {
        [Fact]
        public void TestFindStudentWithHighestGPA()
        {
            Student studentOne = new Student(800180062, "Waite Armstrong", 3.1);
            Student studentTwo = new Student(800180162, "Shaun White", 3.2);
            Student studentThree = new Student(800180262, "Mark Black", 3.0);
            Student.findStudentWithHighestGPA(studentOne, studentTwo, studentThree);
            Assert.Equal(3.2, Student.findStudentWithHighestGPA(studentOne, studentTwo, studentThree).StudentGPA);
        }
    }
}
