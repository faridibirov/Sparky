using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Sparky;

[TestFixture]
public class BankAccountNUnitTests
{
    private BankAccount bankAccount;


    [SetUp]
    public void Setup()
    {
        bankAccount = new(new LogFaker());
    }



    [Test]
    public void BankDeposit_Add100_ReturnTrue()
    {
        var result = bankAccount.Deposit(100);

        ClassicAssert.IsTrue(result);

        Assert.That(bankAccount.balance, Is.EqualTo(100));
    }

}
