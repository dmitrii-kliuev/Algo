using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests
{
    public class PlusOneTests
    {
        [Xunit.Theory]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 4 })]
        [InlineData(new int[] { 1, 1, 9, 9 }, new int[] { 1, 2, 0, 0 })]
        [InlineData(new int[] { 9 }, new int[] { 1, 0 })]
        [InlineData(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 1 })]
        public void PlusOneSolutionTest(int[] input, int[] output)
        {
            // arrange
            var s = new Solution();

            // act
            var actual = s.PlusOne(input);

            // assert
            Assert.Equal(output, actual);
        }

        public class Solution
        {
            public int[] PlusOne(int[] digits)
            {
                var tmp = new List<int>();

                var isAdded = false;
                for (int i = digits.Length - 1; i >= 0; i--)
                {
                    if (isAdded)
                    {
                        tmp.Add(digits[i]);
                        continue;
                    }

                    if (digits[i] + 1 > 9 && i == 0 && !isAdded)
                    {
                        tmp.Add(0);
                        tmp.Add(1);
                        break;
                    }

                    if (digits[i] + 1 > 9)
                    {
                        tmp.Add(0);
                        continue;
                    }

                    if (!isAdded)
                    {
                        tmp.Add(digits[i] + 1);
                        isAdded = true;
                    }
                }

                tmp.Reverse();
                return tmp.ToArray();
            }
        }

        public class Solution2
        {
            public int[] PlusOne(int[] digits)
            {
                //First idea was 
                //  to build the int from the digit -> res = res*10+digit
                //  Then add 1 nad build back the int array

                //Below is a better idea
                //Note: only in case of digit 9, there would be a carry of 1, sum = 0;
                //Only if all digits are 9, hten we need to build a new array of len + 1, with all zeros leading with a 1

                int n = digits.Length;
                for (int i = n - 1; i >= 0; i--)
                {
                    if (digits[i] < 9)
                    {
                        digits[i]++;
                        return digits;//Note to return when first NON 9 occurs
                    }

                    digits[i] = 0;
                }

                //All digits were 9
                int[] newDigits = new int[n + 1];
                newDigits[0] = 1;

                return newDigits;
            }
        }
    }
}
