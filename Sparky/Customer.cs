
namespace Sparky;

public interface ICustomer
{
    public int Discount { get; set; }
    public string GreetMessage { get; set; }
    public bool IsPlatinum { get; set; }
    public int OrderTotal { get; set; }

    string GreetAndCombineNames(string firstName, string lastName);

    public CustomerType GetCustomerDetails();

}


    public class Customer : ICustomer
{
    public int Discount {  set; get; }
    public string GreetMessage { get; set; }

    public bool IsPlatinum { get; set; }

    public Customer()
    {
        Discount = 15;
        IsPlatinum = false;
    }

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
