using Xunit;

namespace Algo.Tests.leetcode
{
    public class NumberOfEmployeesWhoMetTheTarget
    {

        [Theory]
        [InlineData(new int[] { 0, 1, 2, 3, 4 }, 2, 3)]
        public void Test(int[] hours, int target, int expected)
        {
            var actual = NumberOfEmployeesWhoMetTarget(hours, target);
            Assert.Equal(expected, actual);
        }

        public int NumberOfEmployeesWhoMetTarget(int[] hours, int target)
        {
            var result = 0;
            
            for (int i = 0; i < hours.Length; i++)
            {
                if (hours[i] >= target)
                    result++;
            }

            return result;
        }
    }
}
