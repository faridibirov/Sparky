
namespace Sparky;

public class Customer
{
    public string GreetMessage { get; set; }

    public string GreetAndCombineNames(string FirstName, string LastName)
    {
        GreetMessage =  $"Hello, {FirstName} {LastName}";

        return GreetMessage;
    }
}
