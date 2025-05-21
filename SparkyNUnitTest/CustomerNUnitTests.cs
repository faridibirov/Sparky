using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Security.Cryptography.X509Certificates;

namespace Sparky;

[TestFixture]
public class CustomerNUnitTests
{
    private Customer customer;

    [SetUp]
    public void Setup()
    {
        customer = new Customer();
    }


    [Test]
    public void CombineName_InputFirstAndLastName_ReturnFullName()
    {



        //Arrange

        //Act
        customer.GreetAndCombineNames("Ben", "Spark");

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Ben Spark"));
            ClassicAssert.AreEqual(customer.GreetMessage, "Hello, Ben Spark");
            Assert.That(customer.GreetMessage, Does.Contain("ben Spark").IgnoreCase);
            Assert.That(customer.GreetMessage, Does.StartWith("Hello,"));
            Assert.That(customer.GreetMessage, Does.EndWith("Spark"));
            Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        });
    }

    [Test]
    public void GreetMessage_NotGreeted_ReturnsNull()
    {
        //arrange

        //act


        //assert
        ClassicAssert.IsNull(customer.GreetMessage);
    }

    [Test]
    public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
    {
        int result = customer.Discount;
        Assert.That(result, Is.InRange(10, 25));
    }

    [Test]
    public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
    {
        customer.GreetAndCombineNames("ben", "");

        ClassicAssert.IsNotNull(customer.GreetMessage);

        ClassicAssert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));

    }

    [Test]
    public void GreetChecker_EmptyFirstName_ThrowsException()
    {
        var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));

        ClassicAssert.AreEqual("Empty First Name", exceptionDetails.Message);

        Assert.That(()=>customer.GreetAndCombineNames("", "Spark"), Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));


        Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));


        Assert.That(() => customer.GreetAndCombineNames("", "Spark"), Throws.ArgumentException);
    }

    [Test]
    public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
    {
        customer.OrderTotal = 10;
       var result = customer.GetCustomerDetails();

        Assert.That(result, Is.TypeOf<BasicCustomer>());
    }


    [Test]
    public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnPlatinumCustomer()
    {
        customer.OrderTotal = 101;
        var result = customer.GetCustomerDetails();

        Assert.That(result, Is.TypeOf<PlatinumCustomer>());
    }
}
