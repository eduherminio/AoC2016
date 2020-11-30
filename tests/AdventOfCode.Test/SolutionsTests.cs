using AoCHelper;
using System;
using Xunit;

namespace AdventOfCode.Test
{
    public class SolutionsTests
    {
        [Theory]
        [InlineData(typeof(Day_01), "288", "111")]
        public void Solutions(Type type, string sol1, string sol2)
        {
            var instance = Activator.CreateInstance(type) as BaseDay;

            Assert.Equal(sol1, instance.Solve_1());
            Assert.Equal(sol2, instance.Solve_2());
        }
    }
}
