using System;
using Algorithms.ch01;

namespace UnitTests.ch01
{
    public class BitManipulation2IntegerDivisorTests : IntegerDivisorTests
    {
        protected override IIntegerDivisor CreateDivisor()
        {
            return new BitManipulation2IntegerDivisor();
        }
    }
}
