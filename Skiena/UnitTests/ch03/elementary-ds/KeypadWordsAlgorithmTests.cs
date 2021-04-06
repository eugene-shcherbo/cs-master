using Algorithms.ch03.elementaryds;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests.ch03.elementaryds
{
    public abstract class KeypadWordsAlgorithmTests
    {
        [Fact]
        public void ThrowsExceptionWhenDigitIsNotOnKeyPad()
        {
            IKeypadWordsAlgorithm algorithm = CreateAlgorithm();
            Assert.Throws<ArgumentException>(
                () => algorithm.GetWords(new short[] { 1, 2, 10 },
                CreateSimpleEnglishDictionary()));
        }

        [Fact]
        public void ReturnsEmptyWordListIfNoWordsExistForDigits()
        {
            IKeypadWordsAlgorithm algorithm = CreateAlgorithm();
            Assert.Empty(algorithm.GetWords(IntegerToDigits(34567), CreateSimpleEnglishDictionary()));
        }

        [Fact]
        public void ReturnsCorrectListOfWords()
        {
            IKeypadWordsAlgorithm algorithm = CreateAlgorithm();
            var wordsByKeypadDigits = CreateWordsByKeypadDigits();
            var dictionary = CreateSimpleEnglishDictionary();

            foreach (int combination in wordsByKeypadDigits.Keys)
            {
                Assert.Equal(wordsByKeypadDigits[combination], algorithm.GetWords(IntegerToDigits(combination), dictionary));
            }
        }

        private ISet<string> CreateSimpleEnglishDictionary()
        {
            return CreateWordsByKeypadDigits()
                .SelectMany(kv => kv.Value)
                .ToHashSet();
        }

        private static IDictionary<int, string[]> CreateWordsByKeypadDigits()
        {
            return new Dictionary<int, string[]>
            {
                { 269, new[] { "any", "box", "boy" } },
                { 7359, new[] { "rely" } },
                { 4477464, new[] { "hissing" } },
                { 74353, new[] { "rifle", "shelf", "sidle" } }
            };
        }

        private static IEnumerable<short> IntegerToDigits(int num)
        {
            var digits = new List<short>();

            while (num > 0)
            {
                digits.Add((short)(num % 10));
                num /= 10;
            }

            return Enumerable.Reverse(digits);
        }

        protected abstract IKeypadWordsAlgorithm CreateAlgorithm();
    }
}
