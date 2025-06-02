using Moq;
using Xunit;

namespace Sparky;


public class ProductXUnitTests
{
    [Fact]
    public void GetProdcutPrice_PlatinumCustomer_ReturnPriceWith20Discount()
    {
        var product = new Product() { Price = 50 };

        var result = product.GetPrice(new Customer() { IsPlatinum = true });

        Assert.Equal(40, result);
    }

    [Fact]
    public void GetProdcutPriceMOQAbuse_PlatinumCustomer_ReturnPriceWith20Discount()
    {
        var customer = new Mock<ICustomer>();

        customer.Setup(u => u.IsPlatinum).Returns(true);


        var product = new Product() { Price = 50 };

        var result = product.GetPrice(customer.Object);

        Assert.Equal(40, result);
    }
}
