using AdventOfCode;
using Xunit;

namespace AdventOfCodeTests
{
  public class Challenge2Tests
  {
    private Challenge2 _challenge = new Challenge2();

    [Theory]
    [InlineData("12", "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab")]
    public void PartOne_CalculateChecksum(string expected, params string[] input)
    {
      Assert.Equal(expected, _challenge.PartOne(input));
    }

    [Theory]
    [InlineData("fgij", "abcde", "fghij", "klmno", "pqrst", "fguij", "axcye", "wvxyz")]
    public void PartTwo_FindCommonLetters(string exptected, params string[] input)
    {
      Assert.Equal(exptected, _challenge.PartTwo(input));
    }
  }
}
