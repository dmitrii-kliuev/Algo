using System;
using Xunit;

public class ScoreOfAString
{
    /*
    You are given a string s. The score of a string is defined as the sum of the absolute difference between the ASCII values of adjacent characters.

    Return the score of s.



    Example 1:

    Input: s = "hello"

    Output: 13

    Explanation:

    The ASCII values of the characters in s are: 'h' = 104, 'e' = 101, 'l' = 108, 'o' = 111. So, the score of s would be |104 - 101| + |101 - 108| + |108 - 108| + |108 - 111| = 3 + 7 + 0 + 3 = 13.

    Example 2:
    Input: s = "zaz"
    Output: 50

    Explanation:
    The ASCII values of the characters in s are: 'z' = 122, 'a' = 97. So, the score of s would be |122 - 97| + |97 - 122| = 25 + 25 = 50.

    Constraints:

    2 <= s.length <= 100
    s consists only of lowercase English letters.
 */
    [Theory]
    [InlineData("zaz", 50)]
    [InlineData("hello", 13)]
    public void Test(string inputString, int expected)
    {
        var s = new Solution();
        var result = s.ScoreOfString(inputString);

        Assert.Equal(expected, result);
    }
}

public class Solution
{
    public int ScoreOfString(string s)
    {
        var sum = 0;

        for (var i = 1; i < s.Length; i++)
        {
            sum += Math.Abs(s[i] - s[i - 1]);
        }

        return sum;
    }
}