using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class FindWordsContainingCharacter
    {
        [Fact]
        public void Test()
        {
            var words = new[] { "leet", "code" };
            var x = 'e';
            var expected = new[] { 0, 1 };

            var actual = FindWordsContaining(words, x);
            actual.Should().BeEquivalentTo(expected);
        }

        public IList<int> FindWordsContaining(string[] words, char x)
        {
            var result = new List<int>();

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    if(words[i][j] == x)
                    {
                        result.Add(i);
                        break;
                    }
                }
            }

            return result;
        }
    }
}
