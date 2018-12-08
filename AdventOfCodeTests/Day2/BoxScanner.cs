using System;
using Xunit;
using AdventOfCode;
using System.Collections.Generic;

namespace AdventOfCodeTests
{
  public class BoxScannerTests
  {
    private BoxScanner _scanner = new BoxScanner();

    [Theory]
    [InlineData(12, "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab")]
    public void CalculateChecksum_ShouldReturnTheProductOfDoubleAndTripleLetterCounts(int expected, params string[] ids)
    {
      Assert.Equal(expected, _scanner.CalculateChecksum(ids));
    }

    [Theory]
    [InlineData("fgij", "abcde", "fghij", "klmno", "pqrst", "fguij", "axcye", "wvxyz")]
    public void FindCommonLetters_ShouldReturnTheCommonLettersSharedByTheIdsThatOnlyDifferByOneCharacter(string exptected, params string[] ids)
    {
      Assert.Equal(exptected, _scanner.FindCommonLetters(ids));
    }
  }
}
