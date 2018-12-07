using System;
using Xunit;
using AdventOfCode;
using System.Collections.Generic;

namespace AdventOfCodeTests
{
  public class FrequencyCalibratorTests
  {
    private FrequencyCalibrator _calibrator = new FrequencyCalibrator();

    [Theory]
    [InlineData(3, 1, 1, 1)]
    [InlineData(0, 1, 1, -2)]
    [InlineData(-6, -1, -2, -3)]
    public void Sum_ShouldReturnTheSumOfFrequencies(int expected, params int[] frequencies) =>
      Assert.Equal(expected, _calibrator.Sum(frequencies));

    [Theory]
    [InlineData(0, 1, -1)]
    [InlineData(10, 3, 3, 4, -2, -4)]
    [InlineData(5, -6, 3, 8, 5, -6)]
    [InlineData(14, 7, 7, -2, -7, -4)]
    public void FindFirstDuplicate_ShouldReturnTheFirstDuiplicateSummedFrequency(int expected, params int[] frequencies) =>
      Assert.Equal(expected, _calibrator.FindFirstDuplicate(frequencies));
  }
}
