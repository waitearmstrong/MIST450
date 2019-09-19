using System;
using Xunit;
using FirstMVCAppArmstrong.Models;

namespace XUnitTestProject1
{
    public class UndergraduateStudentTest
    {
        [Fact]
        public void TestCreateUndergraduateStudent()
        {
            UndergraduateStudent undergrad = new UndergraduateStudent(800180062, "Waite Armstrong", 3.3, false);
            Assert.Equal(3.3, undergrad.StudentGPA);
        }

        [Fact]
        public void ShouldCalculateUndergradTuitionAmountByStudentType()
        {
            UndergraduateStudent undergrad = new UndergraduateStudent(800180062, "Waite Armstrong", 3.3, false);
            undergrad.calculateTuition();
            Assert.Equal(24000, undergrad.Tuition);
        }
    }
}