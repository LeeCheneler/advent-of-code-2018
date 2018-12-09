using System.Linq;
using AdventOfCode;
using Xunit;

namespace AdventOfCodeTests {
  public class Challenge1Tests {
    private Challenge1 _challenge = new Challenge1 ();

    [Theory]
    [InlineData (3, 1, 1, 1)]
    [InlineData (0, 1, 1, -2)]
    [InlineData (-6, -1, -2, -3)]
    public void PartOne (int expected, params int[] input) {
      Assert.Equal (expected.ToString (), _challenge.PartOne (input.Select (i => i.ToString ())));
    }

    [Theory]
    [InlineData (0, 1, -1)]
    [InlineData (10, 3, 3, 4, -2, -4)]
    [InlineData (5, -6, 3, 8, 5, -6)]
    [InlineData (14, 7, 7, -2, -7, -4)]
    public void PartTwo (int expected, params int[] input) {
      Assert.Equal (expected.ToString (), _challenge.PartTwo (input.Select (i => i.ToString ())));
    }
  }
}
