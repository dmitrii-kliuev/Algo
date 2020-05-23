using Xunit;

namespace Algo.Tests.leetcode
{
    public class PalindromeNumberTest
    {
        [Theory]
        [InlineData(121, true)]
        [InlineData(123, false)]
        [InlineData(-101, false)]
        [InlineData(1221, true)]
        [InlineData(22122, true)]
        public void Test(int num, bool expected)
        {
            var s = new Solution();
            var actual = s.IsPalindrome(num);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public bool IsPalindrome(int x)
            {
                if (x < 0) return false;

                var reverse = Reverse(x);

                return x == reverse;
            }

            public int Reverse(int x)
            {
                var res = 0;

                while (true)
                {
                    res += (x % 10);

                    x /= 10;
                    if (x == 0) break;

                    res *= 10;
                }

                return res;
            }
        }
    }
}
