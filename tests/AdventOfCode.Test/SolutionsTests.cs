using AoCHelper;
using Xunit;

namespace AdventOfCode.Test;

#pragma warning disable IL2067 // Target parameter argument does not satisfy 'DynamicallyAccessedMembersAttribute' in call to target method. The parameter of method does not have matching annotations.
public class SolutionTests
{
    [Theory]
    [InlineData(typeof(Day_01), "288", "111")]
    [InlineData(typeof(Day_02), "47978", "659AD")]
    public static async Task Test(Type type, string sol1, string sol2)
    {
        if (Activator.CreateInstance(type) is BaseProblem instance)
        {
            Assert.Equal(sol1, await instance.Solve_1());
            Assert.Equal(sol2, await instance.Solve_2());
        }
        else
        {
            Assert.Fail($"{type} is not a BaseDay");
        }
    }
}
#pragma warning restore IL2067 // Target parameter argument does not satisfy 'DynamicallyAccessedMembersAttribute' in call to target method. The parameter of method does not have matching annotations.
