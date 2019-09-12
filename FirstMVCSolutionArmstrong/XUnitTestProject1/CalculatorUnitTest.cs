using System;
using Xunit;
using FirstMVCAppArmstrong.Models;

namespace XUnitTestProject1
{
    public class CalculatorUnitTest
    {
        [Fact]
        public void ShouldReturnFirst()
        {
            int expectedLargestNumber = 9;
            int actualLargestNumber;
            Calculator calculator = new Calculator();
            actualLargestNumber = calculator.FindLargestNumber(9,7,2);
            Assert.Equal(expectedLargestNumber, actualLargestNumber);
        }
        [Fact]
        public void ShouldReturnLast()
        {
            int expectedLargestNumber = 7;
            int actualLargestNumber;
            Calculator calculator = new Calculator();
            actualLargestNumber = calculator.FindLargestNumber(5, 1, 7);
            Assert.Equal(expectedLargestNumber, actualLargestNumber);
        }
        [Fact]
        public void ShouldReturnMiddle()
        {
            int expectedLargestNumber = 4;
            int actualLargestNumber;
            Calculator calculator = new Calculator();
            actualLargestNumber = calculator.FindLargestNumber(2, 4, 1);
            Assert.Equal(expectedLargestNumber, actualLargestNumber);
        }
    }
}
