using System;
using Algorithms.ch01;

namespace UnitTests.ch01
{
    public class BitManipulationIntegerDivisorTests : IntegerDivisorTests
    {
        protected override IIntegerDivisor CreateDivisor()
        {
            return new BitManipulationIntegerDivisor();
        }
    }
}
