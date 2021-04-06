using Algorithms.ch01;

namespace UnitTests.ch01
{
    public class NaiveIntegerDivisorTests : IntegerDivisorTests
    {
        protected override IIntegerDivisor CreateDivisor()
        {
            return new NaiveIntegerDivisor();
        }
    }
}
