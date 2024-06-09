using System;
using Xunit;

namespace Algo.Tests
{
    public class ArrayJumpingTest
    {
        [Fact]
        public void Test()
        {
            // arrange
            var arr = new[] { 1, 3, 4, 7, 8, 9, 10, 15, 16, 20, 21 }; // spikes

            var endOfRoad = arr[^1];

            var road = new bool[endOfRoad + 1];

            for (var i = 0; i < arr.Length; i++)
            {
                road[arr[i]] = true;
            }

            // act
            var jumpValue = ArrayJumping.GetSmallestJump(road, endOfRoad);


            // assert
            Assert.Equal(6, jumpValue);
        }
    }

    public static class ArrayJumping
    {
        public static int GetSmallestJump(bool[] road, int endOfRoad)
        {
            if (road == null) throw new Exception("road is null");

            var jump = 1;
            var landingPlace = 0;

            while (true)
            {
                landingPlace += jump;

                if (landingPlace >= endOfRoad)
                {
                    return jump;
                }

                if (road[landingPlace]) // touch the spike
                {
                    jump += 1;
                    landingPlace = 0;
                }
            }
        }
    }
}
