using Bongo.Models.ModelValidations;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bongo.Models;


[TestFixture]
public class DateInFutureAttributeTests
{
    [Test]
    public void DateValidator_InputExpectedDateRange_DateValidity()
    {
        DateInFutureAttribute dateInFutureAttribute = new(()=>DateTime.Now);

        var result = dateInFutureAttribute.IsValid(DateTime.Now.AddSeconds(-100));

        ClassicAssert.AreEqual(true, result);
    }
}
