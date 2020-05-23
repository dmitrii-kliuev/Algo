using System.Collections.Generic;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class HappyNumber
    {
        [Theory]
        [InlineData(19, true)]
        [InlineData(4, false)]
        [InlineData(2, false)]
        public void HappyNumberTest(int num, bool isHappy)
        {
            var s = new Solution();

            var actual = s.IsHappy(num);

            Assert.Equal(isHappy, actual);
        }

        public class Solution
        {
            public bool IsHappy(int n)
            {
                var isHappy = false;
                var curr = n;
                int sum;

                var hs = new HashSet<int>();

                while (true)
                {
                    sum = 0;

                    while (curr != 0)
                    {
                        var tmp = curr % 10;
                        curr /= 10;

                        sum += tmp * tmp;
                    }

                    curr = sum;
                    if (sum == 1)
                    {
                        isHappy = true;
                        break;
                    }

                    if (hs.Contains(sum))
                        break;

                    hs.Add(sum);
                }


                return isHappy;
            }
        }

        #region cool solution. not my
        [Theory]
        [InlineData(19, true)]
        [InlineData(4, false)]
        [InlineData(2, false)]
        public void HappyNumber_Floyd_Cycle_Test(int num, bool isHappy)
        {
            var s = new Solution2();

            var actual = s.IsHappy(num);

            Assert.Equal(isHappy, actual);
        }

        private class Solution2
        {
            public static int DigitSquareSum(int n)
            {
                int sum = 0, tmp;
                while (n != 0)
                {
                    tmp = n % 10;
                    sum += tmp * tmp;
                    n /= 10;
                }
                return sum;
            }

            public bool IsHappy(int n)
            {
                int slow, fast;
                slow = fast = n;
                do
                {
                    slow = DigitSquareSum(slow);
                    fast = DigitSquareSum(fast);
                    fast = DigitSquareSum(fast);
                } while (slow != fast);
                if (slow == 1) return true;
                return false;
            }
        }
        #endregion
    }
}
