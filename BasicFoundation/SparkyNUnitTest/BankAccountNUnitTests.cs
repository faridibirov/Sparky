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

    [Test]
    public void BankLogDummy_LogMockString_ReturnTrue()
    {
        var logMock = new Mock<ILogBook>();

        string desiredOutput = "hello";

        logMock.Setup(u => u.MessageWithReturnStr(It.IsAny<string>())).Returns((string str)=>str.ToLower());

        Assert.That(logMock.Object.MessageWithReturnStr("HELlo"), Is.EqualTo(desiredOutput));

    }

    [Test]
    public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
    {
        var logMock = new Mock<ILogBook>();

        string desiredOutput = "hello";

        logMock.Setup(u => u.LogWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);
        string result = "";

        ClassicAssert.IsTrue(logMock.Object.LogWithOutputResult("Ben", out result));
        Assert.That(result, Is.EqualTo(desiredOutput));

    }

    [Test]
    public void BankLogDummy_LogRefChecker_ReturnTrue()
    {
        var logMock = new Mock<ILogBook>();

        var customer = new Customer();

        var customerNotUsed = new Customer();

        logMock.Setup(u => u.LogWithRefObj(ref customer)).Returns(true);

        ClassicAssert.IsTrue(logMock.Object.LogWithRefObj(ref customer));
        ClassicAssert.IsFalse(logMock.Object.LogWithRefObj(ref customerNotUsed));

    }

    [Test]
    public void BankLogDummy_SetAndGetLogTypeAndSeverityMock_MockTest()
    {
        var logMock = new Mock<ILogBook>();
        logMock.SetupAllProperties();
        logMock.Setup(u => u.LogSeverity).Returns(10);
        logMock.Setup(u => u.LogType).Returns("warning");

        logMock.Object.LogSeverity = 100;
        Assert.That(logMock.Object.LogSeverity, Is.EqualTo(10));
        Assert.That(logMock.Object.LogType, Is.EqualTo("warning"));

        //callbacks

        string logTemp = "Hello, ";
        logMock.Setup(u => u.LogToDb(It.IsAny<string>()))
            .Returns(true).Callback((string str) => logTemp += str);

        logMock.Object.LogToDb("Ben");
        Assert.That(logTemp, Is.EqualTo("Hello, Ben"));



        //callbacks

        int counter = 5;
        logMock.Setup(u => u.LogToDb(It.IsAny<string>()))
            .Returns(true).Callback(() => counter++);

        logMock.Object.LogToDb("Ben");
        logMock.Object.LogToDb("Ben");
        Assert.That(counter, Is.EqualTo(7));

    }


    [Test]

    public void BankLogDummy_VerifyExample()
    {
        var logMock = new Mock<ILogBook>();

        var bankAccount = new BankAccount(logMock.Object);

        bankAccount.Deposit(100);

        Assert.That(bankAccount.GetBalance, Is.EqualTo(100));

        //verification

        logMock.Verify(u=>u.Message(It.IsAny<string>()), Times.Exactly(2));
        logMock.Verify(u=>u.Message("Test"), Times.AtLeastOnce);
        logMock.VerifySet(u=>u.LogSeverity=101, Times.Once);
        logMock.VerifyGet(u=>u.LogSeverity, Times.Once);
    }
}
