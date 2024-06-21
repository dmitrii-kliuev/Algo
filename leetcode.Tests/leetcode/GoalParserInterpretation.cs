using System.Text;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class GoalParserInterpretation
    {
        [Theory]
        [InlineData("G()(al)", "Goal")]
        [InlineData("G()()()()(al)", "Gooooal")]
        [InlineData("(al)G(al)()()G", "alGalooG")]
        public void Test(string command, string expected)
        {
            var actual = Interpret(command);
            Assert.Equal(expected, actual);
        }

        public string Interpret(string command)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == 'G')
                {
                    sb.Append('G');
                }
                else if (command[i] == '(' && command[i + 1] == ')')
                {
                    sb.Append('o');
                    i++;
                }
                else if (command[i] == '(' && command[i + 1] == 'a')
                {
                    sb.Append("al");
                    i += 3;
                }
            }

            return sb.ToString();
        }
    }
}
