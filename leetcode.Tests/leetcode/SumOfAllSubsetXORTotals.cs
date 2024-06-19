using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class SumOfAllSubsetXORTotals
    {
        [Theory]
        [InlineData(new int[] { 1, 3 }, 6)]
        [InlineData(new int[] { 5, 1, 6 }, 28)]
        [InlineData(new int[] { 3, 4, 5, 6, 7, 8 }, 480)]
        public void Test(int[] nums, int expected)
        {
            var actual = SubsetXORSum(nums);
            Assert.Equal(expected, actual);
        }

        public int SubsetXORSum(int[] nums)
        {
            var subset = new List<int>();
            var res = new List<List<int>>();

            int index = 0;
            CalcSubset(nums, res, subset, index);

            var result = 0;
            foreach (var s in res)
            {
                var tmp = 0;
                for (int i = 0; i < s.Count; i++)
                {
                    tmp ^= s[i];
                }

                result += tmp;
            }

            return result;
        }

        private void CalcSubset(int[] nums, List<List<int>> res, List<int> subset, int index)
        {
            res.Add(new List<int>(subset));

            for (int i = index; i < nums.Length; i++)
            {
                subset.Add(nums[i]);

                CalcSubset(nums, res, subset, i + 1);

                subset.RemoveAt(subset.Count - 1);
            }
        }
    }
}
