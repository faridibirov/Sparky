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



    //[Test]
    //public void BankDepositLogFaker_Add100_ReturnTrue()
    //{
    //    BankAccount bankAccount = new(new LogFaker());

    //    var result = bankAccount.Deposit(100);

    //    ClassicAssert.IsTrue(result);

    //    Assert.That(bankAccount.balance, Is.EqualTo(100));
    //}

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


    [Test]
    [TestCase(200, 100)]
    [TestCase(200, 150)]
    public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
    {
        var logMock = new Mock<ILogBook>();
        logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
        logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);

        BankAccount bankAccount = new(logMock.Object);
        bankAccount.Deposit(balance);
        var result = bankAccount.Withdraw(withdraw);

        ClassicAssert.IsTrue(result);

    }

    [Test]
    [TestCase(200, 300)]
    public void BankWithdraw_Withdraw300With200Balance_ReturnsFalse(int balance, int withdraw)
    {
        var logMock = new Mock<ILogBook>();
        logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false);
        logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

        BankAccount bankAccount = new(logMock.Object);
        bankAccount.Deposit(balance);
        var result = bankAccount.Withdraw(withdraw);

        ClassicAssert.IsFalse(result);

    }
}
