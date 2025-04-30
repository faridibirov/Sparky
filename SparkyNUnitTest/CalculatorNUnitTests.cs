
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Runtime.CompilerServices;

namespace Sparky;

[TestFixture]
public class CalculatorNUnitTests
{
    [Test]
    public void AddNumbers_InputTwoInt_GetCorrectAddition()
    {
        // Arrange
        Calculator calc = new();

        // Act 

        int result = calc.AddNumbers(10, 20);

        // Assert

        ClassicAssert.AreEqual(30, result);
    }

    [Test]
    public void IsOddNumber_Checker_True()
    {
        Calculator calc = new();

        bool result = calc.IsOddNumber(3);

        ClassicAssert.AreEqual(true, result);

        // ClassicAssert.That(result, Is.EqualTo(true));

        // ClassicAssert.IsTrue(result);
    }

    [Test]
    public void IsOddNumber_Checker_False()
    {
        Calculator calc = new();

        bool result = calc.IsOddNumber(4);

        ClassicAssert.AreEqual(false, result);

        //ClassicAssert.That(result, Is.EqualTo(false));

        // ClassicAssert.IsFalse(result);
    }

    [Test]
    [TestCase(10, ExpectedResult = false)]
    [TestCase(11, ExpectedResult = true)]
    public bool IsOddChecker_InputNumber_ReturnTrueIfOdd(int a)
    {
        Calculator calc = new();

        return calc.IsOddNumber(a);
    }

    [Test]
    [TestCase(5.4, 10.5)]
    [TestCase(5.43, 10.53)]
    [TestCase(5.49, 10.59)]
    public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
    {
        // Arrange
        Calculator calc = new();

        // Act 

        double result = calc.AddNumbersDouble(a, b);

        // Assert

        ClassicAssert.AreEqual(15.9, result, .2);
    }

}