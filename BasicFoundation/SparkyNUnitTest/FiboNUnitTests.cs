using NUnit.Framework;
namespace Sparky;




[TestFixture]
public class FiboNUnitTests
{
    private Fibo fibo;

    [SetUp]
    public void Setup()
    {
        fibo = new Fibo();
    }


    [Test]
    public void FiboChecker_Range1_ReturnsFiboSeries ()
    {
        fibo.Range = 1;

        var result = fibo.GetFiboSeries();

        List<int> expectedFibo = new() { 0 };

        Assert.That(result, Is.Not.Empty);
        Assert.That(result, Is.Ordered);
        Assert.That(result, Is.EquivalentTo(expectedFibo));

    }



    [Test]
    public void FiboChecker_Range6_ReturnsFiboSeries()
    {
        fibo.Range = 6;

        var result = fibo.GetFiboSeries();

        List<int> expectedFibo = new() {0,1,1,2,3,5};

        Assert.That(result, Does.Contain(3));
        Assert.That(result.Count, Is.EqualTo(6) );
        Assert.That(result, Has.No.Member(4));
        Assert.That(result, Is.EquivalentTo(expectedFibo));

    }

}
