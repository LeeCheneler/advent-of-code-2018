using Xunit;
using AdventOfCode;

namespace AdventOfCodeTests
{
  public class Challenge3Tests
  {
    private Challenge3 _challenge = new Challenge3();

    [Theory]
    [InlineData("4", "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2")]
    public void PartOne_OverlappedCutouts(string expected, params string[] input)
    {
      Assert.Equal(expected, _challenge.PartOne(input));
    }

    [Theory]
    [InlineData("3", "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2")]
    public void PartTwo_UnoverlappedCutoutId(string expected, params string[] input)
    {
      Assert.Equal(expected, _challenge.PartTwo(input));
    }
  }
}
