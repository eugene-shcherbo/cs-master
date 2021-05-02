using Algorithms.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.common
{
    public abstract class StringMatcherTests
    {
        [Theory]
        [MemberData(nameof(TestCases))]
        public void TestFindingString(string text, string pattern, int expected)
        {
            IStringMatcher matcher = GetMatcher();

            int match = matcher.FindIndex(text, pattern);

            Assert.Equal(expected, match);
        }

        public static IEnumerable<object[]> TestCases()
            => new object[][]
            {
                new object[] { "Hello", "ll", 2 },
                new object[] { "Who are you?", " ar", 3 },
                new object[] { "abccabcabc", "abc", 0 },
                new object[] { "lololol", "abc", -1 }
            };

        protected abstract IStringMatcher GetMatcher();
    }
}
