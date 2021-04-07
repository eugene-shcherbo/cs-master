using System.Collections.Generic;
using System.Linq;

namespace Algorithms.ch05.integer_multiplication
{
    public class DecimalInteger
    {
        private readonly LinkedList<short> digits = new LinkedList<short>();

        public DecimalInteger()
        {
            digits.AddFirst(0);
        }

        private DecimalInteger(LinkedList<short> digits)
        {
            this.digits = digits;
        }

        public DecimalInteger Sum(DecimalInteger other)
        {
            LinkedList<short> res = new LinkedList<short>();

            LinkedListNode<short>? digitNode = digits.Last;
            LinkedListNode<short>? otherDigitNode = other.digits.Last;

            short carry = 0;

            while (digitNode is not null || otherDigitNode is not null)
            {
                short sum = (short)(carry + GetDigitValue(digitNode) + GetDigitValue(otherDigitNode));

                res.AddFirst(new LinkedListNode<short>((short)(sum % 10)));
                carry = (short)(sum / 10);

                digitNode = digitNode?.Previous;
                otherDigitNode = otherDigitNode?.Previous;
            }

            if (carry > 0)
            {
                res.AddFirst(carry);
            }

            return new DecimalInteger(res);
        }

        private static short GetDigitValue(LinkedListNode<short>? digitNode)
            => digitNode switch
            {
                null => 0,
                _ => digitNode.Value
            };

        public DecimalInteger PadWithZeros(int numOfZeros)
        {
            if (digits.Count == 1 && digits.First!.Value == 0)
            {
                return this;
            }

            LinkedList<short> res = new LinkedList<short>(digits);

            for (int i = 0; i < numOfZeros; i++)
            {
                res.AddLast(0);
            }

            return new DecimalInteger(res);
        }

        public int ToInt32()
        {
            int res = 0;

            foreach (short digit in digits)
            {
                res *= 10;
                res += digit;
            }

            return res;
        }

        public static DecimalInteger FromInt32(int value)
        {
            LinkedList<short> res = new LinkedList<short>();
            
            while (value > 0)
            {
                res.AddFirst((short)(value % 10));
                value /= 10;
            }

            return new DecimalInteger(res);
        }
    }
}
