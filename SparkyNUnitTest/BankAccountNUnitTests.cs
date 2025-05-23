using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Sparky;

[TestFixture]
public class BankAccountNUnitTests
{
    private BankAccount account;


    [SetUp]
    public void Setup()
    {
    }



    [Test]
    public void BankDepositLogFaker_Add100_ReturnTrue()
    {
        BankAccount bankAccount = new(new LogFaker());

        var result = bankAccount.Deposit(100);

        ClassicAssert.IsTrue(result);

        Assert.That(bankAccount.balance, Is.EqualTo(100));
    }

    [Test]
    public void BankDeposit_Add100_ReturnTrue()
    {
        var logMock = new Mock<ILogBook>();

        logMock.Setup(x => x.Message(""));

        BankAccount bankAccount = new(logMock.Object);

        var result = bankAccount.Deposit(100);

        ClassicAssert.IsTrue(result);

        Assert.That(bankAccount.balance, Is.EqualTo(100));
    }

}
