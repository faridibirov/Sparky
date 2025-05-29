using Xunit;

namespace Sparky;


public class FiboXUnitTests
{
    private Fibo fibo;

  
    public  FiboXUnitTests()
    {
        fibo = new Fibo();
    }


    [Fact]
    public void FiboChecker_Range1_ReturnsFiboSeries()
    {
        fibo.Range = 1;

        var result = fibo.GetFiboSeries();

        List<int> expectedFibo = new() { 0 };

        Assert.NotEmpty(result);
        Assert.Equal(expectedFibo.OrderBy(u=>u), result);
        Assert.True(result.SequenceEqual(expectedFibo));

    }



    [Fact]
    public void FiboChecker_Range6_ReturnsFiboSeries()
    {
        fibo.Range = 6;

        var result = fibo.GetFiboSeries();

        List<int> expectedFibo = new() { 0, 1, 1, 2, 3, 5 };

        Assert.Contains(3, result);
        Assert.Equal(6, result.Count);
        Assert.DoesNotContain(4, result);
        Assert.Equal(expectedFibo, result);

    }

}
