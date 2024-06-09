using Xunit;

namespace Algo.Tests.leetcode
{
    public class RichestCustomerWealth
    {
        [Fact]
        public void Test()
        {
            var arr = new[]
            {
                new[]{2,8,7},
                new[]{7,1,3},
                new[]{1,9,5}
            };


            Assert.Equal(17, Solution.MaximumWealth(arr));
        }

        private static class Solution
        {
            public static int MaximumWealth(int[][] accounts)
            {
                var maxWealth = 0;


                for (var i = 0; i < accounts.Length; i++)
                {
                    var summ = 0;
                    for (var j = 0; j < accounts[0].Length; j++)
                    {
                        summ += accounts[i][j];
                    }

                    if (summ > maxWealth)
                    {
                        maxWealth = summ;
                    }
                }

                return maxWealth;
            }
        }
    }
}
