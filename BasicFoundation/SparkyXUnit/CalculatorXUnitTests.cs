using System.Runtime.CompilerServices;
using Xunit;

namespace Sparky;


public class CalculatorXUnitTests
{
    [Fact]
    public void AddNumbers_InputTwoInt_GetCorrectAddition()
    {
        // Arrange
        Calculator calc = new();

        // Act 

        int result = calc.AddNumbers(10, 20);

        // Assert

        Assert.Equal(30, result);
    }

    [Fact]
    public void IsOddNumber_Checker_True()
    {
        Calculator calc = new();

        bool result = calc.IsOddNumber(3);

       Assert.Equal(true, result);

        // ClassicAssert.That(result, Is.EqualTo(true));

        // ClassicAssert.IsTrue(result);
    }

    [Fact]
    public void IsOddNumber_Checker_False()
    {
        Calculator calc = new();

        bool result = calc.IsOddNumber(4);

       Assert.Equal(false, result);

        //ClassicAssert.That(result, Is.EqualTo(false));

        // ClassicAssert.IsFalse(result);
    }

    [Theory]
    [InlineData(10, false)]
    [InlineData(11, true)]
    public void IsOddChecker_InputNumber_ReturnTrueIfOdd(int a, bool expectedResult)
    {
        Calculator calc = new();

        var result =  calc.IsOddNumber(a);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(5.4, 10.5)]
    [InlineData(5.43, 10.53)]
    [InlineData(5.49, 10.59)]
    public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
    {
        // Arrange
        Calculator calc = new();

        // Act 

        double result = calc.AddNumbersDouble(a, b);

        // Assert

            Assert.Equal(15.9, result, .2);
    }

    [Fact]
    public void OddRanger_InputMinAndMax_ReturnsValidOddNumberRange()
    {
        Calculator calc = new();

        List<int> expectedOddRange = new() { 5, 7, 9 }; //5-10

        //act 
        List<int> result = calc.GetOddRange(5, 10);

        // assert
        Assert.Equal(expectedOddRange,result);
        Assert.Contains(7, result);
        Assert.NotEmpty(result);
        Assert.Equal(3, result.Count);
        Assert.DoesNotContain(6, result);
        Assert.Equal(result.OrderBy(u=>u), result);
       // Assert.That(result, Is.Unique);

    }

}