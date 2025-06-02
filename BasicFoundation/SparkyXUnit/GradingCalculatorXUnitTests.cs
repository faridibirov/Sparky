using Xunit;

namespace Sparky;


public class GradingCalculatorXUnitTests
{
    private GradingCalculator gradingCalculator;

 
    public  GradingCalculatorXUnitTests()
    {
        gradingCalculator = new GradingCalculator();
    }


    [Fact]
    public void GetGrade_InputScore95Attendance90_ReturnsGrade()
    {
        gradingCalculator.Score = 95;
        gradingCalculator.AttendancePercentage = 90;

        Assert.Equal("A", gradingCalculator.GetGrade() );
    }


    [Fact]
    public void GetGrade_InputScore85Attendance90_ReturnsGrade()
    {
        gradingCalculator.Score = 85;
        gradingCalculator.AttendancePercentage = 90;

        Assert.Equal("B", gradingCalculator.GetGrade());
    }

    [Fact]
    public void GetGrade_InputScore65Attendance90_ReturnsGrade()
    {
        gradingCalculator.Score = 65;
        gradingCalculator.AttendancePercentage = 90;

        Assert.Equal("C", gradingCalculator.GetGrade());
    }

    [Fact]
    public void GetGrade_InputScore95Attendance65_ReturnsGrade()
    {
        gradingCalculator.Score = 95;
        gradingCalculator.AttendancePercentage = 65;

        Assert.Equal("B", gradingCalculator.GetGrade());
    }

    [Theory]
    [InlineData(95, 55)]
    [InlineData(65, 55)]
    [InlineData(50, 90)]
    public void GetGrade_FailureScenarios_ReturnsGrade(int score, int attendance)
    {
        gradingCalculator.Score = score;
        gradingCalculator.AttendancePercentage = attendance;

        Assert.Equal("F", gradingCalculator.GetGrade());
    }


    [Theory]
    [InlineData(95, 90, "A")]
    [InlineData(85, 90, "B")]
    [InlineData(65, 90, "C")]
    [InlineData(95, 65, "B")]
    [InlineData(95, 55, "F")]
    [InlineData(65, 55, "F")]
    [InlineData(50, 90, "F")]
    public void GetGrade_InputScoreAttendance_ReturnsGrade(int score, int attendance, string expectedResult)
    {
        gradingCalculator.Score = score;
        gradingCalculator.AttendancePercentage = attendance;

        var result =  gradingCalculator.GetGrade();

        Assert.Equal(expectedResult, result);
    }

}
