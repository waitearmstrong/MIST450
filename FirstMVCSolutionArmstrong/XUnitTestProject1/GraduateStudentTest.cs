using System;
using Xunit;
using FirstMVCAppArmstrong.Models;

namespace XUnitTestProject1
{
    public class GraduateStudentTest
    {
        [Fact]
        public void TestCreateGraduateStudent()
        {
            GraduateStudent grad = new GraduateStudent(800180062, "Waite Armstrong", 3.2, 3000);
            grad.calculateTuition();
            Assert.Equal(17000, grad.Tuition);
        }
        //Should I create a separate test class for every new class? What is considered best practice?
        [Fact]
        public void TestCreatePartTimeGraduateStudent()
        {
            PartTimeGraduateStudent grad = new PartTimeGraduateStudent(800180062, " Austin Kendall", 3.60, 3000.00, 6);
            grad.calculateTuition();
            Assert.Equal(6000, grad.Tuition);
        }

        [Fact]
        public void TestCreatePartTimeGraduateStudentTwo()
        {
            PartTimeGraduateStudent grad = new PartTimeGraduateStudent(800180063, "Jalen Hurts", 3.75, 5000.00, 3);
            grad.calculateTuition();
            Assert.Equal(0, grad.Tuition);
        }
    }
}