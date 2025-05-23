using Moq;
using NUnit.Framework;

namespace Sparky;


[TestFixture]
public class ProductNUnitTests
{
    [Test]
    public void GetProdcutPrice_PlatinumCustomer_ReturnPriceWith20Discount()
    {
        var product = new Product() { Price = 50 };

        var result = product.GetPrice(new Customer() { IsPlatinum = true });

        Assert.That(result, Is.EqualTo(40));
    }

    [Test]
    public void GetProdcutPriceMOQAbuse_PlatinumCustomer_ReturnPriceWith20Discount()
    {
        var customer = new Mock<ICustomer>();

        customer.Setup(u=>u.IsPlatinum).Returns(true);


        var product = new Product() { Price = 50 };

        var result = product.GetPrice(customer.Object);

        Assert.That(result, Is.EqualTo(40));
    }
}
