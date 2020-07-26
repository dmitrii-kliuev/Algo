using Xunit;

namespace Algo.Tests
{
    public class RecursivePatternsTest
    {
        [Fact]
        public void Test()
        {
            var p1 = new Person { Id = 1, Name = "Sheldon", StatusId = 1 };

            var res = p1 is { Name: "Sheldon" };
            Assert.True(res);
        }

        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int StatusId { get; set; }
        }
    }
}
