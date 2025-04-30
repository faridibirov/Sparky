
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

    [Test]
    public void OddRanger_InputMinAndMax_ReturnsValidOddNumberRange()
    {
        Calculator calc = new();

        List<int> expectedOddRange = new() { 5, 7, 9}; //5-10

        //act 
        List<int> result = calc.GetOddRange(5, 10);

        // assert
        Assert.That(result, Is.EquivalentTo(expectedOddRange));
        //ClassicAssert.AreEqual(expectedOddRange, result);
        // ClassicAssert.Contains(7, result);
        Assert.That(result, Does.Contain(7));
        Assert.That(result, Is.Not.Empty);
        Assert.That(result.Count, Is.EqualTo(3));
        Assert.That(result, Has.No.Member(6));
        Assert.That(result, Is.Ordered);
        Assert.That(result, Is.Unique);

    }

}