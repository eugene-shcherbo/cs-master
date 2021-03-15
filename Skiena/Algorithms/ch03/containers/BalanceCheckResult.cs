using System;
namespace Algorithms.ch03.containers
{
    public class BalanceCheckResult : IEquatable<BalanceCheckResult>
    {
        public bool IsBalanced { get; }

        public int? ErrorPosition { get; }

        private BalanceCheckResult(bool balanced, int? position)
        {
            IsBalanced = balanced;
            ErrorPosition = position;
        }

        public static BalanceCheckResult Balanced() => new BalanceCheckResult(true, null);

        public static BalanceCheckResult NotBalanced(int errorPos) => new BalanceCheckResult(false, errorPos);

        public bool Equals(BalanceCheckResult? other)
        {
            if (other is null)
            {
                return false;
            }

            return IsBalanced
                ? other.IsBalanced
                : ErrorPosition == other.ErrorPosition;
        }

        public override int GetHashCode()
        {
            if (IsBalanced)
            {
                return IsBalanced.GetHashCode();
            }

            return ErrorPosition.GetHashCode();
        }
    }
}
