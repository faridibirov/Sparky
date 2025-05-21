
namespace Sparky;

public class Customer
{
    public int Discount = 15;
    public string GreetMessage { get; set; }

    public int OrderTotal { get; set; }

    public string GreetAndCombineNames(string FirstName, string LastName)
    {
        if(string.IsNullOrWhiteSpace(FirstName))
        {
            throw new ArgumentException("Empty First Name");
        }

        GreetMessage =  $"Hello, {FirstName} {LastName}";
        Discount = 20;

        return GreetMessage;
    }

    public CustomerType GetCustomerDetails()
    {
        if (OrderTotal<100)
        {
            return new BasicCustomer();
        }

        return new PlatinumCustomer();
    }
}


public class CustomerType { }

public class BasicCustomer : CustomerType { }

public class PlatinumCustomer : CustomerType { }
