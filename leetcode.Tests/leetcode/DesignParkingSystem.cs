using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class DesignParkingSystem
    {
        [Theory]
        [InlineData(1, 1, 0, new int[] { 1, 2, 3, 1 }, new bool[] { true, true, false, false })]
        public void Test(int big, int medium, int small, int[] cars, bool[] expected)
        {
            var parkingSystem = new ParkingSystem(big, medium, small);

            var actual = new List<bool>();
            foreach (var car in cars)
            {
                var result = parkingSystem.AddCar(car);
                actual.Add(result);
            }

            actual.Should().BeEquivalentTo(expected);
        }

        public class ParkingSystem
        {
            private int _big;
            private int _medium;
            private int _small;

            public ParkingSystem(int big, int medium, int small)
            {
                _big = big;
                _medium = medium;
                _small = small;
            }

            public bool AddCar(int carType)
            {
                switch(carType)
                {
                    case 1:
                        if (_big == 0)
                        {
                            return false;
                        }

                        _big--;
                        return true;

                    case 2:
                        if (_medium == 0)
                        {
                            return false;
                        }

                        _medium--;
                        return true;

                    case 3:
                        if (_small == 0)
                        {
                            return false;
                        }

                        _small--;
                        return true;
                }

                return false;
            }
        }
    }
}
