

using NUnit.Framework;

namespace Sparky;


[TestFixture]
public class GradingCalculatorNUnitTests
{
    private GradingCalculator gradingCalculator;

    [SetUp]
    public void Setup()
    {
        gradingCalculator = new GradingCalculator();
    }


    [Test]
    public void GetGrade_InputScore95Attendance90_ReturnsGrade()
    {
        gradingCalculator.Score = 95;
        gradingCalculator.AttendancePercentage = 90;

        Assert.That(gradingCalculator.GetGrade(), Is.EqualTo("A"));
    }


    [Test]
    public void GetGrade_InputScore85Attendance90_ReturnsGrade()
    {
        gradingCalculator.Score = 85;
        gradingCalculator.AttendancePercentage = 90;

        Assert.That(gradingCalculator.GetGrade(), Is.EqualTo("B"));
    }

    [Test]
    public void GetGrade_InputScore65Attendance90_ReturnsGrade()
    {
        gradingCalculator.Score = 65;
        gradingCalculator.AttendancePercentage = 90;

        Assert.That(gradingCalculator.GetGrade(), Is.EqualTo("C"));
    }

    [Test]
    public void GetGrade_InputScore95Attendance65_ReturnsGrade()
    {
        gradingCalculator.Score = 95;
        gradingCalculator.AttendancePercentage = 65;

        Assert.That(gradingCalculator.GetGrade(), Is.EqualTo("B"));
    }

    [Test]
    [TestCase(95,55)]
    [TestCase(65,55)]
    [TestCase(50,90)]
    public void GetGrade_FailureScenarios_ReturnsGrade(int score, int attendance)
    {
        gradingCalculator.Score = score;
        gradingCalculator.AttendancePercentage = attendance;

        Assert.That(gradingCalculator.GetGrade(), Is.EqualTo("F"));
    }


    [Test]
    [TestCase(95, 90, ExpectedResult ="A")]
    [TestCase(85, 90, ExpectedResult = "B")]
    [TestCase(65, 90, ExpectedResult = "C")]
    [TestCase(95, 65, ExpectedResult = "B")]
    [TestCase(95, 55, ExpectedResult = "F")]
    [TestCase(65, 55, ExpectedResult = "F")]
    [TestCase(50, 90, ExpectedResult = "F")]
    public string GetGrade_InputScoreAttendance_ReturnsGrade(int score, int attendance)
    {
        gradingCalculator.Score = score;
        gradingCalculator.AttendancePercentage = attendance;

       return gradingCalculator.GetGrade();
    }

}
