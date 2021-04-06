using Algorithms.ch05.binary_search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ch05.binary_search
{
    public class BinarySearchSquareRootCalculatorTests : SquareRootCalculatorTests
    {
        protected override ISquareRootCalculator GetCalculator()
            => new BinarySearchSquareRootCalculator();
    }
}
